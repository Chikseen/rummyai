<template>
	<div>
		<h1>Rummy AI</h1>
		<input type="text" v-model="gameId">
		<button v-if="!gameStore.game.gameId" @click="getGame">Get Game Data</button>
		<div v-if="gameStore.game.gameId">
			<p>{{ gameStore.game }}</p>
			<button @click="joinGame">Join Game</button>
		</div>
	</div>
</template>

<script lang="ts">
import { useGameStore } from '@/stores/gameStore'
import { useConnectionStore } from '~/stores/connectionStore';

export default {
	data() {
		return {
			gameId: "",
			gameStore: useGameStore(),
			connectionStore: useConnectionStore()
		}
	},
	methods: {
		async getGame() {
			this.gameStore.fetchGameData(this.gameId);
		},
		async joinGame() {
			await this.gameStore.joinGame(this.gameStore.playerId, this.connectionStore.getConnectionId);
			if (this.gameStore.$state.game.gameState == 1)
				this.$router.push({ name: 'waiting' });
			else
				this.$router.push({ name: 'play' });
		},
	}
}
</script>