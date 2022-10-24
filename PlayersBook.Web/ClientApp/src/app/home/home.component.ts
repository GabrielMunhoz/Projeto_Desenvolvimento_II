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
import { faMicrophone, faMicrophoneSlash} from '@fortawesome/free-solid-svg-icons';
import { SafeSubscriber } from 'rxjs/internal/Subscriber';
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
  iconVoiceOn = faMicrophone;
  iconVoiceOff = faMicrophoneSlash;
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
        this.showFilterButton = false;
        this.showSpinnerButtonFilter = false;
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }

  connectClicked(id: string){
    let teste = document.getElementById(id);
    teste?.removeAttribute("hidden");
    let idPlayer = this.getIdPlayerLoged();

    this._playerData.validateToken().subscribe(suc => {  
      if(!this.checkConnectedAnotherAdvertisement()){
        this._advertisementData.getById(id).subscribe(advertisementCurrent => {
          if(advertisementCurrent){
            if(advertisementCurrent.playerHostId == this.getIdPlayerLoged())
                return alert("Não é possivel conectar você a este grupo.");
            advertisementCurrent.guests.push({playerId : idPlayer});
            this._advertisementData.put(advertisementCurrent).subscribe(suc => {
              const dialogRef = this.dialog.open(ConnectDialogComponent, {
                minWidth: '500px',
                data: advertisementCurrent
              });
              
              dialogRef.afterClosed().subscribe(result => {
                console.log('The dialog was closed');
                sessionStorage.setItem("advertisementConnected", "true");
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
      }else{
        alert("Voce ja está conectado a outro anuncio"); 
        teste?.setAttribute("hidden","true");
      }
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

  desconnectGroup(id: string){
    let teste = document.getElementById(id);
    teste?.removeAttribute("hidden");

    let idPlayer = this.getIdPlayerLoged();

    this._playerData.validateToken().subscribe(logged => {
      this._advertisementData.getById(id).subscribe(advertisementCurrent => {
        if(advertisementCurrent){
          advertisementCurrent.guests = advertisementCurrent.guests.filter(x => x.playerId != idPlayer).length > 0 ? advertisementCurrent.guests.filter(x => x.playerId != idPlayer) : null as any ;
          
          this._advertisementData.put(advertisementCurrent).subscribe(suc => {
            
              teste?.setAttribute("hidden","true");
              sessionStorage.setItem("advertisementConnected", "false");
              this.get();
            
          }, err => {
            console.log(err)
            alert("Falha ao desconectar a este grupo");
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

  showConnectButton(ad: IAdvertisement){
    //não pode ser o host
    //não pode estar entre os participantes 
    //pode estar zerado os participantes 
    let isHost = this.checkPlayerHost(ad.playerHostId);
    let isConnected = !this.checkUserConnected(ad);
    let isEmpty = ad.guestCount == 0; 

    return !isHost && isConnected && isEmpty
  }

  showDesconnectButton(ad: IAdvertisement){
    //não pode ser o host
    //Deve estar entre os participantes 
    //não pode estar zerado os participantes 
    let isHost = this.checkPlayerHost(ad.playerHostId);
    let isConnected = this.checkUserConnected(ad); 
    let notEmpty = ad.guestCount > 0; 
    return !isHost && isConnected && notEmpty
  }

  ///Return true if user is connected
  checkUserConnected(ad: IAdvertisement){
    let playerLoggedId = this.getIdPlayerLoged();
    let some = ad.guests.find(x => x.playerId == playerLoggedId);
    return some;  
  }

  ///Return true if user is host
  checkPlayerHost(idHost:string){
    let playerLoggedId = this.getIdPlayerLoged();
    return playerLoggedId.toLocaleLowerCase() === idHost.toLocaleLowerCase()
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
    let playerLogged = localStorage.getItem("PlayerLogged");
    if (playerLogged){
      let session = JSON.parse(playerLogged); 
      return session?.player?.id; 
    }
    return null; 
  }

  getAdvertisementOwner(): boolean{
    console.log("Entrou aqui")
    let sessionAdvertisement = sessionStorage.getItem("ownerAdvertisement") ? JSON.parse(sessionStorage.getItem("ownerAdvertisement") || '') : "";
    let userLoggedId = this.getIdPlayerLoged(); 

    console.log(sessionAdvertisement.playerHostId+"   "+userLoggedId)

    if(sessionAdvertisement.playerHostId == userLoggedId)
      return true; 
    return false;
  }

  createAdvertisement() {
    console.log("Entrou aqui")
    this._playerData.validateToken().subscribe(suc => {
        let haveAdvertisement = this.getAdvertisementOwner();
        if(!haveAdvertisement){
          const dialogRef = this.dialog.open(CreateAdvertisementDialogComponent, {
            minWidth: '500px',
            minHeight: '40em'
          });
      
          dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
            this.get(); 
          });
        }else{
          alert("Você ja possui um anuncio criado!")
      }
    }, err => {
      if(err.status == 401){
        this.router.navigate(['/login']);
      }else{
        alert("Falha interna no servidor");
      }
    }); 
    
  }
  
  checkConnectedAnotherAdvertisement() : boolean{
    let isConnected = JSON.parse(sessionStorage.getItem("advertisementConnected") || '') || false
    return  isConnected;
  }
}