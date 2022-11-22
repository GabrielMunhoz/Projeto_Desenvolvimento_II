import { Component, OnInit, ChangeDetectionStrategy, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { faThumbsUp, faThumbsDown, faUser} from '@fortawesome/free-solid-svg-icons';
import { IAdvertisementDetail } from 'src/app/models/Advertisements/IAdvertisementDetail';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { IPlayerProfile } from 'src/app/models/PlayerProfile/iplayer-profile';
import { AdvertisementDataService } from 'src/app/_data-services/advertisement-Data.Service';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';
import { PlayerProfileDataServiceService } from 'src/app/_data-services/player-profile-data.service';

@Component({
  selector: 'app-player-profile-info',
  templateUrl: './player-profile-info.component.html',
  styleUrls: ['./player-profile-info.component.css']
})
export class PlayerProfileInfoComponent implements OnInit {

  playerID: string = ''; 

  faThumbsUp = faThumbsUp; 
  faUser = faUser; 
  faThumbsDown = faThumbsDown;
  
  baseUrl :string
  player: IPlayer; 
  playerProfile: IPlayerProfile

  historyAds : IAdvertisementDetail[]

  constructor(
    private playerDataService : PlayerDataService,
    private profileDataService: PlayerProfileDataServiceService,
    private advertisementDataService: AdvertisementDataService,
    public dialog: MatDialog,
    public route : ActivatedRoute,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('playerid');
    if(id){
      this.playerID = id; 
      this.FillPlayerProfile();
      this.FillHistoryAdvertisements(); 
    }
  }
  FillHistoryAdvertisements() {
    this.advertisementDataService.getbyHistoryPlayerId(this.playerID).subscribe(
      suc => {
        this.historyAds = suc;
        console.log(suc)
      },
      err => {
        console.log(err.error)
        alert("Não foi possivel recuperar o historico")
      })
      
  }

  FillPlayerProfile() {
      this.profileDataService.getByPlayerId(this.playerID).subscribe(suc => {
        this.playerProfile = suc;
      },
      err => {
        alert("Não foi possivel encontrar um perfil")
      })
  }

}
