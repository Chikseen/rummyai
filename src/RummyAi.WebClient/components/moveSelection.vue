<template>
	<div>
		<p class="card" v-for="(card, index) in stack?.cards" :key="index" @click="onCardSelect(card)">
			{{ card.suit }} : {{ card.rank }}
		</p>
	</div>
</template>

<script lang="ts">
import type { Card } from '~/domain/models/Card';
import { Stack } from '~/domain/models/Stack';

export default {
	props: {
		stack: {
			type: Object as PropType<Stack>,
			required: true
		}
	},
	methods: {
		onCardSelect(card: Card) {
			this.$emit('onCardSelect', card);
		}
	},
}
</script>

<style lang="scss" scoped>
.card {
	border: 1px solid black;
}
</style>