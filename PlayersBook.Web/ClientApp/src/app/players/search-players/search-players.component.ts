import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPlayer } from 'src/app/models/Player/IPlayer';
import { PlayerDataService } from 'src/app/_data-services/player-Data.Service';

@Component({
  selector: 'app-search-players',
  templateUrl: './search-players.component.html',
  styleUrls: ['./search-players.component.css']
})
export class SearchPlayersComponent implements OnInit {

  PlayersSearch: IPlayer[] = []; 

  BaseUrl : string;

  searchTerm: string; 

  constructor( private playerDataService: PlayerDataService, public router: Router, @Inject('BASE_URL') baseUrl: string) 
  {
    this.BaseUrl = baseUrl; 
  }


  ngOnInit(): void {
    this.playerDataService.get().subscribe(
      suc => {
        console.log(suc);
        this.PlayersSearch = suc;
      },
      err => {
        alert("Falha ao obter os jogadores"); 
        console.log(err.error); 
      }
    )
  }

  viewProfile(idProfile: string){
    this.router.navigate(["playerprofileinfo/"+idProfile])
  }
}
