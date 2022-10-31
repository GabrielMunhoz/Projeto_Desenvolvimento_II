import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { IPlayerLogin } from "../models/IPlayerLogin";
import { IPlayerResponse } from "../models/Player/IPlayerResponse";

@Injectable()
export class PlayerDataService{
    module : string = "/api/player"; 

    /**
     *
     */
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        
    }
    get(){
        return this.http.get(this.module);
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
    authenticate(data:IPlayerLogin): Observable<IPlayerResponse>{
        return this.http.post<IPlayerResponse>(this.module+"/authenticate", data);
    }
    userLogged(){
        let user = localStorage.getItem("PlayerLogged")
        if(user) {
          return true;
        }
        return false;
      }

}