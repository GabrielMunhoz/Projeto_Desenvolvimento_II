import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IAdvertisementGrouped } from '../models/Advertisements/advertisementsGrouped';
import { AdvertisementDataService } from '../_data-services/advertisementDataService';
import { CreateAdvertisementDialogComponent } from './views/create-advertisement-dialog/create-advertisement-dialog.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  animal: string = "";
  name: string = "";
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
        this.advertisementsGrouped.forEach(x => console.log(x))
        console.log(this.advertisementsGrouped); 
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }

  alert(id: string){
    alert(id)
  }

  createAdvertisement(): void {
    const dialogRef = this.dialog.open(CreateAdvertisementDialogComponent, {
      minWidth: '400px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}