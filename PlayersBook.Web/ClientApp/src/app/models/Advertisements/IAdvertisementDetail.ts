import { IPlayer } from "../Player/IPlayer";

export interface IAdvertisementDetail{
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
    guests: IPlayer[];
}