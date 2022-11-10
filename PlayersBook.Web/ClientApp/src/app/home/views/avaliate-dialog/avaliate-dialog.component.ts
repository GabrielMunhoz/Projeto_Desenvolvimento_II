import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IAdvertisement } from 'src/app/models/Advertisements/Iadvertisement';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { AdvertisementDataService } from 'src/app/_data-services/advertisement-Data.Service';
import { faThumbsUp, faThumbsDown} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-avaliate-dialog',
  templateUrl: './avaliate-dialog.component.html',
  styleUrls: ['./avaliate-dialog.component.css']
})
export class AvaliateDialogComponent implements OnInit {

  public guests: IPlayer[] = []

  faThumbsDown = faThumbsDown;
  faThumbsUp = faThumbsUp;

  constructor(
    public dialogRef: MatDialogRef<AvaliateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IAdvertisement,
    public advertisementeDataService : AdvertisementDataService
  ) { }

  ngOnInit(): void {
    this.retrieveGuests()
  }

  retrieveGuests() {
    this.advertisementeDataService.getById(this.data.id).subscribe(suc => {
      this.guests = suc.guests; 
      this.guests.push(suc.host)
      console.log(this.guests)
    }, err => {
      console.log(err.error)
      alert("Falha ao recuperar o anuncio"); 
    })
  }

  avaliatePositive(playerId:string){
    
    let avaliate = {
      playerId: playerId,
      avaliate: true
    };
    this.advertisementeDataService.avaliateGuest(avaliate).subscribe(suc => {
      alert("Obrigado por avaliar o colega")
    }, err => {
      alert("Falha ao avaliar")
    });

  }
  avaliateNegative(playerId:string){
    let avaliate = {
      playerId: playerId,
      avaliate: false
    };
    this.advertisementeDataService.avaliateGuest(avaliate).subscribe(suc => {
      alert("Obrigado por avaliar o colega")
    }, err => {
      alert("Falha ao avaliar")
    });
  }

  onOkClick(): void {
    this.dialogRef.close();
  }
}
