import { Game } from "~/domain/models/Game"

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
}