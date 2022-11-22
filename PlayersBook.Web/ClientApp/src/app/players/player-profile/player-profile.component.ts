import { Component, OnInit, ChangeDetectionStrategy, ViewEncapsulation, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faThumbsUp, faThumbsDown, faUser, faEdit} from '@fortawesome/free-solid-svg-icons';
import { IAdvertisementDetail } from 'src/app/models/Advertisements/IAdvertisementDetail';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { IPlayerProfile } from 'src/app/models/PlayerProfile/iplayer-profile';
import { AdvertisementDataService } from 'src/app/_data-services/advertisement-Data.Service';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';
import { PlayerProfileDataServiceService } from 'src/app/_data-services/player-profile-data.service';
import { EditProfileDialogComponent } from './edit-profile-dialog/edit-profile-dialog.component';

@Component({
  selector: 'app-player-profile',
  templateUrl: './player-profile.component.html',
  styleUrls: ['./player-profile.component.css']
})
export class PlayerProfileComponent implements OnInit {

  faThumbsUp = faThumbsUp; 
  faUser = faUser; 
  faThumbsDown = faThumbsDown;
  faEdit = faEdit;
  
  baseUrl : string;
  player: IPlayer; 
  playerProfile: IPlayerProfile

  historyAds : IAdvertisementDetail[]

  constructor(
    private playerDataService : PlayerDataService,
    private profileDataService: PlayerProfileDataServiceService,
    private advertisementDataService: AdvertisementDataService,
    public dialog: MatDialog,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.FillPlayerProfile();
    this.FillHistoryAdvertisements(); 
  }
  
  FillHistoryAdvertisements() {
    let player = this.playerDataService.userAuthenticated(); 
    if(!player)
      return;
    
    this.advertisementDataService.getbyHistoryPlayerId(player.id).subscribe(
      suc => {
        this.historyAds = suc;
        suc.forEach( x => {
          x.guests = x.guests.filter(x => x !== null);
          x.guests.push(x.host);
          x.guestCount = x.guests.length;
        })
        this.historyAds = suc;
      },
      err => {
        console.log(err.error)
        alert("Não foi possivel recuperar o historico")
      })
      
  }

  FillPlayerProfile() {
    let player = this.playerDataService.userAuthenticated(); 
    if(player){
      this.profileDataService.getByPlayerId(player.id).subscribe(suc => {
        this.playerProfile = suc;
      },
      err => {
        alert("Não foi possivel encontrar um perfil")
      })
    }
  }

  editPlayerProfile(){
    const dialogRef = this.dialog.open(EditProfileDialogComponent, {
      minWidth: '300px',
      data: this.playerProfile
    });
    
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
