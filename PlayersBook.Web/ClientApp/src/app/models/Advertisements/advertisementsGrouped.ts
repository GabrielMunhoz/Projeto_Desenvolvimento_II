import {IAdvertisement} from "./advertisement";

export interface IAdvertisementGrouped{
    GameCategory : string; 
    Advertisements : IAdvertisement[]; 
}