<template>
	<gameboard />
</template>

<script lang="ts">
export default {
	setup() {
		definePageMeta({
			middleware: 'check-game-state'
		})
	},
}
</script>