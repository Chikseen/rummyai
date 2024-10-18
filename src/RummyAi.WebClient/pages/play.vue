<template>
	<div>
		<p>{{ gameStore.game }}</p>
		<button @click="$router.push('/')">HOME</button>
	</div>
</template>

<script>
export default {
	data() {
		return {
			gameStore: useGameStore(),
		}
	},
	methods: {

	},
}
</script>