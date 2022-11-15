import { IPlayerProfile } from "../PlayerProfile/iplayer-profile";

export interface IPlayer{
    id: string,
    name: string,
    lastname: string,
    email: string
    nickname: string;
    password: string;
    playerProfile: IPlayerProfile
}