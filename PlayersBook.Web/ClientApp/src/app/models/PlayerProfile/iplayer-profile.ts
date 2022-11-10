import { IChannelStreams } from "../channelStreams/ichannel-streams";
import { IGameCategory } from "../IgameCategory";
import { IPlayer } from "../Player/IPlayer";

export interface IPlayerProfile {
    id: string;
    playerId: string;
    player: IPlayer;
    channelStreams: IChannelStreams[];
    description: string; 
    ratingPositive: number;
    ratingNegative: number;
    imageUrl: string;
    gamesCategoryProfile: IGameCategory[];
}
