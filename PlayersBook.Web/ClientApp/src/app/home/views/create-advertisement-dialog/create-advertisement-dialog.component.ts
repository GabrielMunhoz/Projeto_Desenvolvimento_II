import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IGameCategory } from 'src/app/models/IgameCategory';
import { GameDataService } from 'src/app/_data-services/gameCategoryDataService';

@Component({
  selector: 'app-create-advertisement-dialog',
  templateUrl: './create-advertisement-dialog.component.html',
  styleUrls: ['./create-advertisement-dialog.component.css']
})
export class CreateAdvertisementDialogComponent implements OnInit {

  public advertisementForm: FormGroup = this.fb.group({}); 

  public groupCategories = ["DUO", "TRIO", "TIME"]

  public gamesCategories : IGameCategory[] = [];

  constructor(
    private fb : FormBuilder,
    public dialogRef: MatDialogRef<CreateAdvertisementDialogComponent>,
    private gameDataService: GameDataService
    ) { }

  ngOnInit(): void {
    this.getGamesCategories();
    this.advertisementForm = this.fb.group({
      GameCategory : ['', [Validators.required]],
      GroupCategory : ['', [Validators.required]],
      IsActive : [true, [Validators.required]],
      PlayerHostId : [this.getIdPlayerLoged(), [Validators.required]],
      PlayerHostName : [{value : this.getNicknamePlayerLoged(), disabled:true}, [Validators.required]],
    })
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  publish(){
    alert(this.advertisementForm.value);
    console.log(this.advertisementForm.value);
    this.dialogRef.close();
    this.advertisementForm.reset();
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
