import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";

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
    post(data: any){
        return this.http.post(this.module, data);
    }
    put(data: any){
        return this.http.put(this.module, data);
    }
    delete(playerId: string){
        return this.http.delete(this.module +"/"+ playerId);
    }
    authenticate(data:any){
        return this.http.post(this.module+"/authenticate", data);
    }

}