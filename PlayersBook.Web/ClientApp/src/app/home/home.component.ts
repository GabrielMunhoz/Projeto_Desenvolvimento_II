import { Component } from '@angular/core';
import { IAdvertisement } from '../models/advertisementModel';
import { AdvertisementDataService } from '../_data-services/advertisementDataService';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  /**
   *
   */
  advertisements : IAdvertisement[] = [];

  constructor( private _advertisementData : AdvertisementDataService) {
    this.get(); 
  }

  get(){
    this._advertisementData.get().subscribe(
      data1 => {
        this.advertisements = data1;
        console.log(data1); 
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }
}
