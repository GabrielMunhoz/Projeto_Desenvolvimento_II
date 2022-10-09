import {IAdvertisement} from "./Iadvertisement";

export interface IAdvertisementGrouped{
    GameCategory : string; 
    Advertisements : IAdvertisement[]; 
}