import { Pipe, PipeTransform } from '@angular/core';
import { IPlayer } from '../models/Player/IPlayer';

@Pipe({
  name: 'searchPlayers',
  pure: false
})
export class SearchPlayersPipe implements PipeTransform {

  transform(playersList: IPlayer[], valor?: string): IPlayer[] {
    const nickName = valor ? valor : "";
    console.log("entrou aqui")
    console.log(nickName);
    return playersList.filter(
      (player) => 
        player.nickname.toLocaleLowerCase().includes(nickName.toLocaleLowerCase())
    );
  }

}
