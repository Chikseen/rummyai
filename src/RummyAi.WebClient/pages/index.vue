<template>
	<div>
		<h1>Rummy AI</h1>
		<input type="text" v-model="gameId">
		<button @click="getGame">Join Game</button>
		<div v-if="gameStore.game != null">
			<p>{{ gameStore.game }}</p>
			<button @click="joinGame">Join Game</button>
		</div>
	</div>
</template>

<script lang="ts">
import { useGameStore } from '@/stores/gameStore'

export default {
	data() {
		return {
			gameId: "",
			gameStore: useGameStore(),
		}
	},
	methods: {
		// temp helper because I am lazy
		uuidv4() {
			return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
				(+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
			);
		},
		async getGame() {
			this.gameStore.fetchGameData(this.gameId);
		},
		async joinGame() {
			const playerId = this.uuidv4();
			this.gameStore.joinGame(playerId);
			this.$router.push({ name: 'waiting' });
		},
	}
}
</script>