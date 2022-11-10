import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPlayerProfile } from '../models/PlayerProfile/iplayer-profile';

@Injectable({
  providedIn: 'root'
})
export class PlayerProfileDataServiceService {

  module : string = "/api/playerprofile"; 
  baseUrl: string; 
    /**
     *
     */
    constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        console.log(baseUrl);
    }
    get(){
        return this.http.get(this.module);
    }
    getByPlayerId(playerId: string) : Observable<IPlayerProfile>{
      return this.http.get<IPlayerProfile>(this.module + "/getbyplayerid/" + playerId);
    }
    getImageProfile(url:string){ 
        return this.http.get(this.baseUrl+"/"+url);
    }
    validateToken(){
        return this.http.get(this.module + "/validateToken");
    }
    post(data: any){
        return this.http.post(this.module, data);
    }
    put(data: any){
        return this.http.put(this.module, data);
    }
    delete(playerId: string){
        return this.http.delete(this.module +"/"+ playerId);
    }
}
