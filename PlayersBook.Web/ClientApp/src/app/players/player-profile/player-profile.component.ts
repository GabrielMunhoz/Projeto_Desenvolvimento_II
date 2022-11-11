import { Component, OnInit } from '@angular/core';
import { faThumbsUp, faThumbsDown} from '@fortawesome/free-solid-svg-icons';
import { IAdvertisementDetail } from 'src/app/models/Advertisements/IAdvertisementDetail';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { IPlayerProfile } from 'src/app/models/PlayerProfile/iplayer-profile';
import { AdvertisementDataService } from 'src/app/_data-services/advertisement-Data.Service';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';
import { PlayerProfileDataServiceService } from 'src/app/_data-services/player-profile-data.service';

@Component({
  selector: 'app-player-profile',
  templateUrl: './player-profile.component.html',
  styleUrls: ['./player-profile.component.css']
})
export class PlayerProfileComponent implements OnInit {

  faThumbsUp = faThumbsUp; 
  faThumbsDown = faThumbsDown;

  player: IPlayer; 

  playerProfile: IPlayerProfile

  historyAds : IAdvertisementDetail[]

  constructor(
    private playerDataService : PlayerDataService,
    private profileDataService: PlayerProfileDataServiceService,
    private advertisementDataService: AdvertisementDataService
  ) { }

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
        console.log(suc);
        this.historyAds = suc;
        console.log("Historico");
        console.log(this.historyAds);
      },
      err => {
        console.log(err.error)
        alert("Não foi possivel recuperar o historico")
      })
      
  }

  FillPlayerProfile() {
    let player = this.playerDataService.userAuthenticated(); 
    if(player){
      console.log(player);
      this.profileDataService.getByPlayerId(player.id).subscribe(suc => {
        console.log(suc);
        this.playerProfile = suc;
        console.log(this.playerProfile);
      },
      err => {
        alert("Não foi possivel encontrar um perfil")
      })
    }
  }



}
