import { Game } from "~/domain/models/Game"
import type { Move, MoveResult } from "~/domain/models/Move";

export default {
	async GetGame(gameId: string): Promise<Game> {
		var config = useRuntimeConfig()
		const game: Game = await $fetch(`${config.public.API_ENDPOINT_BASE}/Game/GetGame?gameId=${gameId}`, {
			method: 'GET'
		})
		return game;
	},
	async JoinGame(gameId: string, playerId: string, connectionId: string): Promise<Game> {
		var config = useRuntimeConfig()
		const game: Game = await $fetch(`${config.public.API_ENDPOINT_BASE}/Game/AddPlayer?gameId=${gameId}`, {
			method: 'POST',
			body: {
				PlayerId: {
					Id: playerId,
				},
				ConenctionId: connectionId
			}
		})
		return game;
	},
	async StartGame(gameId: string): Promise<Game> {
		var config = useRuntimeConfig()
		const game: Game = await $fetch(`${config.public.API_ENDPOINT_BASE}/Game/StartGame?gameId=${gameId}`, {
			method: 'GET'
		})
		return game;
	},
	async SubmitMove(move: Move): Promise<MoveResult> {
		var config = useRuntimeConfig()
		const moveResult: MoveResult = await $fetch(`${config.public.API_ENDPOINT_BASE}/Game/MakeMove`, {
			method: 'POST',
			body: move
		})
		return moveResult;
	},
}