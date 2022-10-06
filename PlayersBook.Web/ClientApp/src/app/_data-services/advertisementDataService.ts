import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAdvertisement } from "../models/advertisementModel";

@Injectable()
export class AdvertisementDataService{
    module : string = "/api/advertisement"; 

    /**
     *
     */
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        
    }
    get(): Observable<IAdvertisement[]>{
        return this.http.get<IAdvertisement[]>(this.module);
    }
    post(data: IAdvertisement){
        return this.http.post(this.module, data);
    }
    put(data: IAdvertisement){
        return this.http.put(this.module, data);
    }
    
    delete( advertisementId: string ){
        return this.http.delete(this.module +"/"+ advertisementId);
    }

}