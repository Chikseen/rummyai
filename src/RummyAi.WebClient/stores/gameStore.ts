import { defineStore } from 'pinia'
import GameApi from '~/services/apis/gameApi'
import { Game } from '~/domain/models/Game'

export const useGameStore = defineStore('gameStore', {
	state: () => (
		{
			game: {} as Game,
		}
	),
	actions: {
		async fetchGameData(gameId: string) {
			this.game = await GameApi.GetGame(gameId);
		},
		async joinGame(playerId: string, connectionId: string) {
			this.game = await GameApi.JoinGame(this.game.gameId.id, playerId, connectionId);
		},
		async startGame() {
			this.game = await GameApi.StartGame(this.game.gameId.id);
		},
	},
})