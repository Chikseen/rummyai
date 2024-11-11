import type { PlayerId } from "./PlayerId";
import type { Stack } from "./Stack";

export class PlayerCards {
    playerId: PlayerId
    stack: Stack

    public constructor(
        playerId: PlayerId,
        stack: Stack) {
        this.playerId = playerId;
        this.stack = stack;
    }
}