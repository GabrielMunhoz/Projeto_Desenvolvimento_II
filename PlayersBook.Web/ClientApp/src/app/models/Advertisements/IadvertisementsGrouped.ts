import { IGameCategory } from "../IgameCategory";
import {IAdvertisement} from "./Iadvertisement";

export interface IAdvertisementGrouped{
    gameCategory : IGameCategory; 
    advertisements : IAdvertisement[]; 
}