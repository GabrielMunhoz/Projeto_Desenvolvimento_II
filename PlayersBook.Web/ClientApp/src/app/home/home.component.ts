import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IAdvertisement } from '../models/Advertisements/Iadvertisement';
import { IAdvertisementGrouped } from '../models/Advertisements/IadvertisementsGrouped';


import { AdvertisementDataService } from '../_data-services/advertisement-Data.Service';
import { PlayerDataService } from '../_data-services/player-Data.Service';
import { ConnectDialogComponent } from './views/connect-dialog/connect-dialog.component';
import { CreateAdvertisementDialogComponent } from './views/create-advertisement-dialog/create-advertisement-dialog.component';
import { faMicrophone, faMicrophoneSlash} from '@fortawesome/free-solid-svg-icons';
import { AvaliateDialogComponent } from './views/avaliate-dialog/avaliate-dialog.component';
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
  validatedToken: boolean = false;
  /**
   *
   */
  advertisementsGrouped : IAdvertisementGrouped[] = [];
  constructor(
    private _advertisementData : AdvertisementDataService,
    private _playerData : PlayerDataService,
    public dialog: MatDialog,
    private router: Router) {
    this.validateToken(); 
    this.get(); 
  }

  get(){
    this._advertisementData.getGrouped().subscribe(
      advertisementsGrouped => {
        if(advertisementsGrouped.length > 0 ){
          this.advertisementsGrouped = advertisementsGrouped;
          this.showFilterButton = false;
          this.showSpinnerButtonFilter = false;
        }else {
          this.mockAdvertisements()
        }
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }

  connectClicked(id: string){
    let buttonConnect = document.getElementById(id);
    buttonConnect?.removeAttribute("hidden");
    let idPlayer = this.getIdPlayerLoged();

    this._playerData.validateToken().subscribe(suc => {  
      if(!this.checkConnectedAnotherAdvertisement()){
        this._advertisementData.getByIdReferenceAsync(id).subscribe(advertisementCurrent => {
          if(advertisementCurrent){
            if(advertisementCurrent.playerHostId == this.getIdPlayerLoged())
                return alert("Não é possivel conectar você a este grupo.");  
            advertisementCurrent.guests.push({playerId : idPlayer});
            this._advertisementData.put(advertisementCurrent).subscribe(suc => {
              const dialogRef = this.dialog.open(ConnectDialogComponent, {
                minWidth: '300px',
                data: advertisementCurrent
              });
              
              dialogRef.afterClosed().subscribe(result => {
                console.log('The dialog was closed');
                sessionStorage.setItem("advertisementConnected", "true");
                this.get(); 
                buttonConnect?.setAttribute("hidden","true");
              });
            }, err => {
              console.log(err)
              alert("Falha ao conectar a este grupo");
              buttonConnect?.setAttribute("hidden","true");
            })
            
          }
        }, err => {
          console.log(err)
          alert(err.error.message);
          buttonConnect?.setAttribute("hidden","true");
        })
      }else{
        alert("Voce ja está conectado a outro anuncio"); 
        buttonConnect?.setAttribute("hidden","true");
      }
    }, 
    err => {
      if(err.status == 401){
        buttonConnect?.setAttribute("hidden","true");
        this.router.navigate(['/login']);
      }else{
        alert("Falha interna no servidor");
        buttonConnect?.setAttribute("hidden","true");
      }
    })
    
  }

  desconnectGroup(id: string){
    let buttonDesconnect = document.getElementById(id);
    buttonDesconnect?.removeAttribute("hidden");

    let idPlayer = this.getIdPlayerLoged();

    this._playerData.validateToken().subscribe(logged => {
      this._advertisementData.getByIdReferenceAsync(id).subscribe(advertisementCurrent => {
        if(advertisementCurrent){
          advertisementCurrent.guests = advertisementCurrent.guests.filter(x => x.playerId != idPlayer).length > 0 ? advertisementCurrent.guests.filter(x => x.playerId != idPlayer) : null as any ;
          
          this._advertisementData.put(advertisementCurrent).subscribe(suc => {
            
            const dialogRef = this.dialog.open(AvaliateDialogComponent, {
              minWidth: '250px',
              data: advertisementCurrent
            });
            
            dialogRef.afterClosed().subscribe(result => {
              console.log('The dialog was closed');
              
              this.get(); 
            });
            
            sessionStorage.setItem("advertisementConnected", "false");
            buttonDesconnect?.setAttribute("hidden","true");
          }, err => {
            console.log(err)
            alert("Falha ao desconectar a este grupo");
            buttonDesconnect?.setAttribute("hidden","true");
          })
          
        }
      }, err => {
        console.log(err)
        alert(err.error.message);
        buttonDesconnect?.setAttribute("hidden","true");
      })
    }, 
    err => {
      if(err.status == 401){
        buttonDesconnect?.setAttribute("hidden","true");
        this.router.navigate(['/login']);
      }else{
        alert("Falha interna no servidor");
        buttonDesconnect?.setAttribute("hidden","true");
      }
    })
    
  }

  finishAdvertisement(ad: IAdvertisement){
    let buttonFinish = document.getElementById(ad.id);
    buttonFinish?.removeAttribute("hidden");
    ad.isActive = false; 
    this._advertisementData.delete(ad.id).subscribe(
    suc=>{
      alert("Anuncio Finalizado")
      sessionStorage.removeItem("ownerAdvertisement");
      buttonFinish?.setAttribute("hidden","true");
      this.get(); 
    }, 
    err=>{
      console.log(err);
      alert(err?.error?.message)
      this.get(); 
      buttonFinish?.setAttribute("hidden","true");
    })
  }

  showConnectButton(ad: IAdvertisement){
    //não pode ser o host
    //não pode estar entre os participantes 
    //pode estar zerado os participantes 
    let isHost = this.checkPlayerHost(ad);
    let isConnected = !this.checkUserConnected(ad);
    let isEmpty = ad.guestCount >= 0; 

    return !isHost && isConnected && isEmpty && this.validGroupCountGuest(ad)
  }
  
  validGroupCountGuest(ad: IAdvertisement) {
    switch(ad.groupCategory) {
      case "DUO":
        return ad.guestCount < 1;
      case "TRIO":
        return ad.guestCount < 2;
      case "TEAM":
        return ad.guestCount < 4; 
        default:
          return true;
    }

  }

  showDesconnectButton(ad: IAdvertisement){
    //não pode ser o host
    //Deve estar entre os participantes 
    //não pode estar zerado os participantes 
    let isHost = this.checkPlayerHost(ad);
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
  checkPlayerHost(ad:IAdvertisement){
    let playerLoggedId = this.getIdPlayerLoged();
    sessionStorage.setItem("ownerAdvertisement", JSON.stringify(ad))
    return playerLoggedId.toLocaleLowerCase() === ad.playerHostId.toLocaleLowerCase()
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
    let sessionAdvertisement = sessionStorage.getItem("ownerAdvertisement") ? JSON.parse(sessionStorage.getItem("ownerAdvertisement") || '') : "";
    let userLoggedId = this.getIdPlayerLoged(); 
    if(sessionAdvertisement.playerHostId == userLoggedId)
      return true; 
    return false;
  }

  createAdvertisement() {
    if(this.getAdvertisementOwner()){
      alert("Você ja possui um anuncio criado!");
      return
    }

    this._playerData.validateToken().subscribe(suc => {
        let haveAdvertisement = this.getAdvertisementOwner();
        if(!haveAdvertisement){
          const dialogRef = this.dialog.open(CreateAdvertisementDialogComponent, {
            minWidth: '350px',
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
    let session = sessionStorage.getItem("advertisementConnected");
    if(session)
    {
      if(this.getAdvertisementOwner()) return true;
      
      let isConnected = JSON.parse(session);
        return  isConnected;
    }
    return false;
  }

  validateToken() {
    this._playerData.validateToken().subscribe(suc => {
      this.validatedToken =  true;
    }, err => {
      this.validatedToken =  false;
    });
  }


  mockAdvertisements(){
    console.log("Entrou no mock")
    this.advertisementsGrouped = JSON.parse('[{"gameCategory": {"id": "00000000-0000-0000-0000-000000000000","idTwitch": 0,"name": "VALORANT","boxArtUrl": "https://static-cdn.jtvnw.net/ttv-boxart/516575-150x200.jpg"},"advertisements": [{"id": "00cb3747-c87c-4cc9-83d5-08dacdbca8631","gameCategory": "VALORANT","groupCategory": "DUO","tagHostGame": "gmunho#2204","linkDiscord": "","expireIn": "2022-11-24T22:38:58.8676823","voiceChannel": true,"isActive": true,"playerHostId": "d0f606a2-622c-46b8-a844-ae0e817b18391","playerHostName": "Gmunho","guestCount": 1,"guests": [{"playerId": "46d4bcdc-d095-4ae7-0f24-08dacdbdbea51"}]},{"id": "8fbeb219-9750-46b8-83d8-08dacdbca863","gameCategory": "VALORANT","groupCategory": "TRIO","tagHostGame": "mike#4332","linkDiscord": "https://discord.gg/aDabGQ5p","expireIn": "2022-11-24T22:49:27.6126397","voiceChannel": true,"isActive": true,"playerHostId": "dec3dc5a-ae0a-4694-0f23-08dacdbdbea5","playerHostName": "MIke","guestCount": 2,"guests": [{"playerId": "2c76f576-79b5-4951-0f25-08dacdbdbea51"}]}]},{"gameCategory": {"id": "00000000-0000-0000-0000-000000000000","idTwitch": 0,"name": "Counter-Strike: Global Offensive","boxArtUrl": "https://static-cdn.jtvnw.net/ttv-boxart/32399_IGDB-150x200.jpg"},"advertisements": [{"id": "26be429e-5b11-443d-83d6-08dacdbca8631","gameCategory": "Counter-Strike: Global Offensive","groupCategory": "DUO","tagHostGame": "Rafa#2322","linkDiscord": "","expireIn": "2022-11-24T22:44:23.8646183","voiceChannel": true,"isActive": true,"playerHostId": "c967c3a0-af87-4696-178f-08dab8602b0c1","playerHostName": "Rafa","guestCount": 1,"guests": []}]},{"gameCategory": {"id": "00000000-0000-0000-0000-000000000000","idTwitch": 0,"name": "FIFA 23","boxArtUrl": "https://static-cdn.jtvnw.net/ttv-boxart/1745202732_IGDB-150x200.jpg"},"advertisements": [{"id": "810c989e-6f2f-479f-83d7-08dacdbca8631","gameCategory": "FIFA 23","groupCategory": "DUO","tagHostGame": "","linkDiscord": "https://discord.gg/aDabGQ5p","expireIn": "2022-11-24T22:47:33.1592355","voiceChannel": true,"isActive": true,"playerHostId": "40ccad3b-c526-4367-0f22-08dacdbdbea51","playerHostName": "marceloOliveira","guestCount": 1,"guests": []}]}]')
  }

}
