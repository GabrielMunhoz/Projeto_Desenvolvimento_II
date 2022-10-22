export interface IAdvertisement{
    id: string;
    gameCategory : string; 
    groupCategory : string;
    linkDiscord : string;
    tagHostGame : string;
    ExpireIn : Date;
    isActive : boolean; 
    playerHostId : string; 
    playerHostName: string;
    guestCount : number;
}