import { defineStore } from 'pinia'
import GameApi from '~/services/apis/gameApi'
import { Game } from '~/domain/models/Game'
import Uuid from '~/services/helper/uuid'
import { PlayerId } from '~/domain/models/PlayerId'
import { Stack } from '~/domain/models/Stack'
import type { PlayerCards } from '~/domain/models/PlayerCards'

export const useGameStore = defineStore('gameStore', {
	state: () => (
		{
			game: {} as Game,
			selectedStack: {} as Stack,
			otherPlayerCards: {} as PlayerCards[],
			playerId: {} as PlayerId
		}
	),
	actions: {
		setGame(game: Game) {
			const router = useRouter()

			if (game.gameState == 3)
				router.push("/play")

			this.game = game;
			this.otherPlayerCards = game.playerCards.filter(player => player.playerId.id != this.playerId.id);
			this.selectedStack = new Stack([]);
		},
		setPlayerId() {
			var playerId: string | null = localStorage.getItem('playerId');
			if (playerId == null) {
				var uuid = Uuid.getUuidv4()
				playerId = uuid;
				localStorage.setItem('playerId', uuid);
			}
			this.playerId = new PlayerId(playerId);
		},
		async fetchGameData(gameId: string) {
			this.game = await GameApi.GetGame(gameId);
		},
		async joinGame(playerId: PlayerId, connectionId: string) {
			this.game = await GameApi.JoinGame(this.game.gameId.id, playerId.id, connectionId);
		},
		async startGame() {
			this.game = await GameApi.StartGame(this.game.gameId.id);
		},
	},
	getters: {
		getCurrentPlayerStack(): Stack {
			return this.game.playerCards.find(player => player.playerId.id == this.playerId.id)!.stack;
		},
	}
})