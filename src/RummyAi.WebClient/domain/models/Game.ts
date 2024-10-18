import { GameState } from "~/domain/enums/GameState";
import type { GameId } from "./GameId";
import type { PlayerId } from "./PlayerId";

export class Game {
    gameId: GameId;
    gameState: GameState;
    stack: any;
    turn: number;
    players: PlayerId[];
    currentPlayer: any | null;
    playerCards: any;
    created: string;

    public constructor(
        gameId: GameId,
        gameState: GameState,
        stack: any,
        turn: number,
        players: PlayerId[],
        currentPlayer: PlayerId,
        playerCards: any,
        created: string) {
        this.gameId = gameId;
        this.gameState = gameState;
        this.stack = stack;
        this.turn = turn;
        this.players = players;
        this.currentPlayer = currentPlayer;
        this.playerCards = playerCards;
        this.created = created;
    }
}