import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IAdvertisement } from '../models/Advertisements/Iadvertisement';
import { IAdvertisementGrouped } from '../models/Advertisements/IadvertisementsGrouped';
import { AdvertisementDataService } from '../_data-services/advertisementDataService';
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
  /**
   *
   */
  advertisementsGrouped : IAdvertisementGrouped[] = [];
  constructor(private _advertisementData : AdvertisementDataService,
    public dialog: MatDialog) {
    this.get(); 
  }

  get(){
    this._advertisementData.getGrouped().subscribe(
      advertisementsGrouped => {
        this.advertisementsGrouped = advertisementsGrouped;
        this.showFilterButton = false;
        this.showSpinnerButtonFilter = false;
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }

  connectClicked(id: string, idPlayer : string){
    if(idPlayer == this.getIdPlayerLoged())
      return alert("Não é possivel conectar você a este grupo.");

      this._advertisementData.getById(id).subscribe(advertisementCurrent => {
        if(advertisementCurrent){
          const dialogRef = this.dialog.open(ConnectDialogComponent, {
            minWidth: '500px',
            data: advertisementCurrent
          });
          
          dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
            this.get(); 
          });
        }
      }, err => {
        console.log(err)
      })
  }

  testeFiltroCategory(adGrouped : IAdvertisementGrouped){
    this.showFilterButton = true;
    this.advertisementsGrouped = this.advertisementsGrouped.filter(x => x.gameCategory.name.toLocaleLowerCase() == adGrouped.gameCategory.name.toLocaleLowerCase())
  }

  limparFiltro(){
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
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.get(); 
    });
  }
  
}