import { IPlayer } from "../Player/IPlayer";
import { IPlayerReference } from "../Player/IPlayerReference";

export interface IAdvertisement{
    id: string;
    gameCategory : string; 
    groupCategory : string;
    linkDiscord : string;
    tagHostGame : string;
    ExpireIn : Date;
    isActive : boolean; 
    voiceChannel : boolean; 
    playerHostId : string; 
    playerHostName: string;
    guestCount : number;
    guests: IPlayerReference[];
}