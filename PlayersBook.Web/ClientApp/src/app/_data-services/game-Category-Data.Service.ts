import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGameCategory } from "../models/IgameCategory";

@Injectable()
export class GameDataService{
    module : string = "/api/gamesCategory"; 

    /**
     *
     */
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        
    }
    get(): Observable<IGameCategory[]>{
        return this.http.get<IGameCategory[]>(this.module);
    }
    getGameByName(gameName: string): Observable<IGameCategory[]>{
        return this.http.get<IGameCategory[]>(this.module+"/getgamecategorybyname/"+gameName);
    }
    getGrouped(): Observable<IGameCategory[]>{
        return this.http.get<IGameCategory[]>(this.module + "/advertisementsGrouped");
    }
    post(data: IGameCategory){
        return this.http.post(this.module, data);
    }
    put(data: IGameCategory){
        return this.http.put(this.module, data);
    }
    
    delete( advertisementId: string ){
        return this.http.delete(this.module +"/"+ advertisementId);
    }

}