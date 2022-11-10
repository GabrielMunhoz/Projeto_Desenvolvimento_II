import { Component, OnInit } from '@angular/core';
import { faThumbsUp, faThumbsDown} from '@fortawesome/free-solid-svg-icons';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { IPlayerProfile } from 'src/app/models/PlayerProfile/iplayer-profile';
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

  constructor(
    private playerDataService : PlayerDataService,
    private profileDataService: PlayerProfileDataServiceService
  ) { }

  ngOnInit(): void {
    this.FillPlayerProfile();
    
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
