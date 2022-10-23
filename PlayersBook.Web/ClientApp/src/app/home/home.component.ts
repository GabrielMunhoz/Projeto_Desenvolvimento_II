import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IAdvertisement } from '../models/Advertisements/Iadvertisement';
import { IAdvertisementGrouped } from '../models/Advertisements/IadvertisementsGrouped';
import { IPlayerReference } from '../models/Player/IPlayerReference';
import { AdvertisementDataService } from '../_data-services/advertisementDataService';
import { PlayerDataService } from '../_data-services/playerDataService';
import { ConnectDialogComponent } from './views/connect-dialog/connect-dialog.component';
import { CreateAdvertisementDialogComponent } from './views/create-advertisement-dialog/create-advertisement-dialog.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  animal: string = "";
  name: string = "";
  showFilterButton: boolean = false;
  showSpinnerButtonFilter: boolean = false;
  spinner:boolean = false;
  /**
   *
   */
  advertisementsGrouped : IAdvertisementGrouped[] = [];
  constructor(
    private _advertisementData : AdvertisementDataService,
    private _playerData : PlayerDataService,
    public dialog: MatDialog,
    private router: Router) {
    this.get(); 
  }

  get(){
    this._advertisementData.getGrouped().subscribe(
      advertisementsGrouped => {
        this.advertisementsGrouped = advertisementsGrouped;
        console.log(this.advertisementsGrouped)
        this.showFilterButton = false;
        this.showSpinnerButtonFilter = false;
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }

  connectClicked(id: string, idPlayer : string){
    let teste = document.getElementById(id);
    teste?.removeAttribute("hidden");
    

    this._playerData.validateToken().subscribe(suc => {
      if(idPlayer == this.getIdPlayerLoged())
      return alert("Não é possivel conectar você a este grupo.");
    
      this._advertisementData.getById(id).subscribe(advertisementCurrent => {
        if(advertisementCurrent){
          advertisementCurrent.guests.push({playerId : idPlayer});
          this._advertisementData.put(advertisementCurrent).subscribe(suc => {
            const dialogRef = this.dialog.open(ConnectDialogComponent, {
              minWidth: '500px',
              data: advertisementCurrent
            });
            
            dialogRef.afterClosed().subscribe(result => {
              console.log('The dialog was closed');
              this.get(); 
              teste?.setAttribute("hidden","true");
            });
          }, err => {
            console.log(err)
            alert("Falha ao conectar a este grupo");
            teste?.setAttribute("hidden","true");
          })
          
        }
      }, err => {
        console.log(err)
        alert(err.error.message);
        teste?.setAttribute("hidden","true");
      })
    }, 
    err => {
      if(err.status == 401){
        teste?.setAttribute("hidden","true");
        this.router.navigate(['/login']);
      }else{
        alert("Falha interna no servidor");
        teste?.setAttribute("hidden","true");
      }
    })
    
  }

  
  checkUserConnected(guests: IPlayerReference[]){
    let playerLoggedId = this.getIdPlayerLoged();

    console.log(guests)

    let some = guests.some(x => x.playerId == playerLoggedId);

    return some;
  }

  filterCategory(adGrouped : IAdvertisementGrouped){
    this.showFilterButton = true;
    this.advertisementsGrouped = this.advertisementsGrouped.filter(x => x.gameCategory.name.toLocaleLowerCase() == adGrouped.gameCategory.name.toLocaleLowerCase())
  }

  clearFilter(){
    this.showSpinnerButtonFilter = true;
    this.get();
  }

  getIdPlayerLoged(){
    let session = JSON.parse(localStorage.getItem("PlayerLogged") || ''); 
    return session?.player?.id; 
  }

  createAdvertisement(): void {
    const dialogRef = this.dialog.open(CreateAdvertisementDialogComponent, {
      minWidth: '500px',
      minHeight: '40em'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.get(); 
    });
  }
  
}