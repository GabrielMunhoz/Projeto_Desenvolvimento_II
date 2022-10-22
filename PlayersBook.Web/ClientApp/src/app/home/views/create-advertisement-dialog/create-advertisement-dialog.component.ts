import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IGameCategory } from 'src/app/models/IgameCategory';
import { AdvertisementDataService } from 'src/app/_data-services/advertisementDataService';
import { GameDataService } from 'src/app/_data-services/gameCategoryDataService';

@Component({
  selector: 'app-create-advertisement-dialog',
  templateUrl: './create-advertisement-dialog.component.html',
  styleUrls: ['./create-advertisement-dialog.component.css']
})
export class CreateAdvertisementDialogComponent implements OnInit {

  advertisementForm: FormGroup = this.fb.group({}); 

  groupCategories = ["DUO", "TRIO", "TIME"]

  gamesCategories : IGameCategory[] = [];

  spinner : boolean = false;

  constructor(
    private fb : FormBuilder,
    public dialogRef: MatDialogRef<CreateAdvertisementDialogComponent>,
    private gameDataService: GameDataService,
    private advertisementDataService : AdvertisementDataService
    ) { }

  ngOnInit(): void {
    this.getGamesCategories();
    this.advertisementForm = this.fb.group({
      GameCategory : ['', [Validators.required]],
      GroupCategory : ['', [Validators.required]],
      TagHostGame : ['',],
      LinkDiscord : ['',],
      IsActive : [true, [Validators.required]],
      PlayerHostId : [this.getIdPlayerLoged(), [Validators.required]],
      PlayerHostName : [{value : this.getNicknamePlayerLoged(), disabled:true}, [Validators.required]],
    })
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  getUrlImgage(){
    return "https://static-cdn.jtvnw.net/ttv-boxart/516575-150x200.jpg"
  }

  publish(){
    this.spinner = true;
    let ad = this.advertisementForm.value; 

    this.advertisementDataService.post(ad).subscribe(result => {
      console.log(result);
      this.spinner = !this.spinner;
      this.dialogRef.close();
      this.advertisementForm.reset();
    },
    err => {
      this.spinner = !this.spinner;
      console.log(err.error)
      let error = JSON.parse(err.error.message)
      alert(error[0]);
    })

  }
  
  getNicknamePlayerLoged(){
    let session = JSON.parse(localStorage.getItem("PlayerLogged") || ''); 
    return session?.player?.nickname; 
  }
  getIdPlayerLoged(){
    let session = JSON.parse(localStorage.getItem("PlayerLogged") || ''); 
    return session?.player?.id; 
  }

  getGamesCategories(){
    this.gameDataService.get().subscribe(gc => {
      this.gamesCategories = gc; 
    }, err => {
      console.log(err)
    })
  }

}
