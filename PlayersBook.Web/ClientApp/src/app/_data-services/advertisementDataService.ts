import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAdvertisement } from "../models/Advertisements/Iadvertisement";
import { IAdvertisementGrouped } from "../models/Advertisements/IadvertisementsGrouped";

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
    getGrouped(): Observable<IAdvertisementGrouped[]>{
        return this.http.get<IAdvertisementGrouped[]>(this.module + "/advertisementsGrouped");
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