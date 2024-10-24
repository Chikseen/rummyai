<template>
	<div>
		<p>{{ gameStore.game }}</p>
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
	}
}
</script>