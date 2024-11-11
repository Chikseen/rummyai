<template>
	<div class="card">
		<p>{{ card?.suit }}</p>
		<p>{{ card?.rank }}</p>
	</div>
</template>

<script lang="ts">
import { Card } from '~/domain/models/Card';

export default {
	props: {
		card: { type: Object as PropType<Card>, required: true },
	}
}
</script>

<style lang="scss" scoped>
.card {
	border: 1px solid black;
	width: 50px;
	height: 50px;
	display: flex;
	flex-direction: column;
	justify-content: space-evenly;
	align-items: center;
	border-radius: 10px;

	p {
		margin: 0;
	}
}
</style>