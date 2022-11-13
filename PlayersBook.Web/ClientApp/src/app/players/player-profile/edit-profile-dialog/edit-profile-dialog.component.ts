import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IChannelStreams } from 'src/app/models/channelStreams/ichannel-streams';
import { IGameCategory } from 'src/app/models/IgameCategory';
import { IPlayerProfile } from 'src/app/models/PlayerProfile/iplayer-profile';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete'
import { MatChipInputEvent } from '@angular/material/chips'
import { PlayerProfileDataServiceService } from 'src/app/_data-services/player-profile-data.service';
import { GameDataService } from 'src/app/_data-services/game-Category-Data.Service';
import { faXmark, faCheck} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-edit-profile-dialog',
  templateUrl: './edit-profile-dialog.component.html',
  styleUrls: ['./edit-profile-dialog.component.css']
})
export class EditProfileDialogComponent implements OnInit {

  //Icons
  faXmark = faXmark;
  faCheck = faCheck;
  fileOk = false; 

  //Loading
  consultingChannel: boolean = false; 
  consultingGamesCategory: boolean = false; 
  uploadingFile: boolean = false; 

  profileForm: UntypedFormGroup
  playerProfile: IPlayerProfile;
  
  gamesCategory: IGameCategory[];
  
  //Forms Properties
  //Channel list
  @ViewChild('channelInput') channelInput: ElementRef<HTMLInputElement>;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  channelStreams: IChannelStreams[] = []; 
  allChannelStreamsString: IChannelStreams[] = [];
  channelCtrl = new FormControl('');

  //GamesCategories
  @ViewChild('gameInput') gameInput: ElementRef<HTMLInputElement>;
  gamesCategories: IGameCategory[] = []; 
  allGamesCategories: IGameCategory[] = [];
  gameCtrl = new FormControl('');

  //Subir o file no evento de change do componente

  //Retornar um feedback com um spinner e um certinho 
  imageFile: File

  constructor(
    public dialogRef: MatDialogRef<EditProfileDialogComponent>,
    private fb : UntypedFormBuilder,
    private playerProfileService: PlayerProfileDataServiceService,
    private gameCategoryDataService: GameDataService,
    @Inject(MAT_DIALOG_DATA) public data: IPlayerProfile
    ) { 
      this.playerProfile = data; 
      this.channelStreams = this.playerProfile.channelStreams; 
      this.gamesCategories = this.playerProfile.gamesCategoryProfile; 
    }

  ngOnInit(): void {
    this.profileForm = this.fb.group({
      description : [this.playerProfile.description, [Validators.required]],
      nickname : ['', [Validators.required]],
    })
  }

  updateProfile(){
    this.playerProfile.gamesCategoryProfile = this.gamesCategories; 
    this.playerProfile.channelStreams = this.channelStreams; 
    this.playerProfile.description = this.profileForm.controls?.description?.value; 
    this.playerProfileService.put(this.playerProfile).subscribe(
      suc => {
        alert("Atualizado com sucesso:")
        console.log(suc)
        this.dialogRef.close();
      },
      err => {
        console.error(err.error);
        
      }
    )
  }

  onNoClick(){
    this.dialogRef.close();
  }

  removeChannelStream(channelStream: IChannelStreams){
    const index = this.channelStreams.indexOf(channelStream);

    if (index >= 0) {
      this.channelStreams.splice(index, 1);
    }
  }

  addChannel(event: MatChipInputEvent): void {
    this.consultingChannel = !this.consultingChannel;
    const value = (event.value);
    if (value) {
      this.playerProfileService.getChannelStream(value).subscribe(
            suc => {
              this.allChannelStreamsString = suc;
              this.consultingChannel = !this.consultingChannel;
          }, 
          err => {
            console.error(err.error);
            alert("Falha ao buscar os streamers")
            this.consultingChannel = !this.consultingChannel;
          })
    }
  }

  selectedChannel(event: MatAutocompleteSelectedEvent): void {
    this.channelStreams.push(event.option.value);
    this.channelInput.nativeElement.value = '';
    this.channelCtrl.setValue(null);
    this.allChannelStreamsString = [];
  }

  //GamesCategory
  removeGameCategory(game: IGameCategory){
    const index = this.gamesCategories.indexOf(game);

    if (index >= 0) {
      this.gamesCategories.splice(index, 1);
    }
  }

  addGame(event: MatChipInputEvent): void {
    this.consultingGamesCategory = !this.consultingGamesCategory;
    const gameName = (event.value);
    if (gameName) {
      this.gameCategoryDataService.getGameByName(gameName).subscribe(
            suc => {
              this.allGamesCategories = suc;
              this.consultingGamesCategory = !this.consultingGamesCategory;
          }, 
          err => {
            console.error(err.error);
            alert("Falha ao buscar os streamers")
            this.consultingGamesCategory = !this.consultingGamesCategory;
          })
    }
  }

  selectedGame(event: MatAutocompleteSelectedEvent): void {
    this.gamesCategories.push(event.option.value);
    this.gameInput.nativeElement.value = '';
    this.gameCtrl.setValue(null);
    this.allGamesCategories = [];
  }

  onChangeFileUpload(event:any) {
    this.uploadingFile = !this.uploadingFile
    this.imageFile = event.target.files[0];
    this.onUpload()
}

  onUpload() {
      this.playerProfileService.uploadImageProfile(this.imageFile, this.playerProfile.playerId).subscribe(
          suc => {
            alert(suc);
            console.log(suc);
            this.playerProfile.imageUrl = suc; 
            this.uploadingFile = !this.uploadingFile;
            this.fileOk = !this.fileOk; 
          },
          err => {
            console.error(err.error);
            alert("Falha ao importar o arquivo")
            this.uploadingFile = !this.uploadingFile;
            this.fileOk = false;
          }
      );
  }

}
