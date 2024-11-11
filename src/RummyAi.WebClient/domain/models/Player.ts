import type { PlayerId } from "./PlayerId";

export class Player {
	playerId: PlayerId;
	playerType: number;

	public constructor(
		playerId: PlayerId,
		playerType: number) {
		this.playerType = playerType;
		this.playerId = playerId;
	}
}