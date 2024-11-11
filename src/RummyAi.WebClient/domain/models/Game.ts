import { GameState } from "~/domain/enums/GameState";
import type { GameId } from "./GameId";
import type { PlayerId } from "./PlayerId";
import type { PlayerCards } from "./PlayerCards";
import type { Stack } from "./Stack";
import type { Player } from "./Player";

export class Game {
    gameId: GameId;
    gameState: GameState;
    hiddenStack: Stack;
    openStack: Stack[];
    turn: Number;
    players: PlayerId[];
    currentPlayer: Player | null;
    playerCards: PlayerCards[];
    created: string;

    public constructor(
        gameId: GameId,
        gameState: GameState,
        hiddenStack: Stack,
        openStack: Stack[],
        turn: Number,
        players: PlayerId[],
        currentPlayer: Player,
        playerCards: PlayerCards[],
        created: string) {
        this.gameId = gameId;
        this.gameState = gameState;
        this.hiddenStack = hiddenStack;
        this.openStack = openStack;
        this.turn = turn;
        this.players = players;
        this.currentPlayer = currentPlayer;
        this.playerCards = playerCards;
        this.created = created;
    }
}