import { Component, OnInit } from '@angular/core';
import { PlayerDataService } from '../_data-services/playerDataService';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  players: any = []; 
  player: any = {}; 
  playerLogin: any = {}; 
  showList: boolean = true; 

  constructor(private playerDataService: PlayerDataService) { }

  ngOnInit(): void {
  }

  get(){
    this.playerDataService.get().subscribe((data1 : any) => {
      this.players = data1;
      console.log(data1); 
    }, err => {
      console.log(err);
      alert("Erro interno");
    })
  }
  post(){
    this.playerDataService.post(this.player).subscribe((data1:any) => {
      if(data1 != null){
        alert("Üsuario cadastrado: "+ data1.name);
      }else{
        alert("Üsuario não cadastrado: "+ data1.name);
      }
    }, err => {
      console.log(err);
      alert("Erro interno");
    });

  }

  authenticate(){
    this.playerLogin = {
      nickname: "gmunho",
      password: "teste"
    }
    this.playerDataService.authenticate(this.playerLogin).subscribe((data1:any) => {
      if(data1 != null){
        localStorage.setItem("PlayerLogged", JSON.stringify(data1));
        this.get();
      }else{
        alert("usuario não cadastrado: "+ data1.name);
      }
    }, err => {
      console.log(err);
      alert("Erro interno");
    });
  }


}
