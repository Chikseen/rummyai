import type { Game } from "./Game";
import type { GameId } from "./GameId";
import type { PlayerId } from "./PlayerId";
import type { Stack } from "./Stack";

export class Move {
	gameId: GameId
	playerId: PlayerId
	stack: Stack

	public constructor(
		gameId: GameId,
		playerId: PlayerId,
		stack: Stack) {
		this.gameId = gameId;
		this.playerId = playerId;
		this.stack = stack;
	}
}

export class MoveResult {
	game: Game
	isMoveValid: boolean

	public constructor(
		game: Game,
		isMoveValid: boolean
	) {
		this.game = game;
		this.isMoveValid = isMoveValid;
	}
}