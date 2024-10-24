<template>
	<div>
		<h2>Waiting for Players</h2>
		<p>{{ gameStore.game }}</p>
		<button @click="startGame">Start Game</button>
		<button @click="$router.push('/')">HOME</button>
	</div>
</template>

<script>
export default {
	setup() {
		definePageMeta({
			middleware: 'check-game-state'
		})
	},
	data() {
		return {
			gameStore: useGameStore(),
		}
	},
	methods: {
		async startGame() {
			this.gameStore.startGame();
			this.$router.push({ name: 'play' });
		}
	},
}
</script>