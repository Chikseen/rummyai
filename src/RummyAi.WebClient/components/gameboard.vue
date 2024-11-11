<template>
	<div class="gameBoard">
		<div class="controllInterface">
			<button @click="makeMove">Submit Move</button>
		</div>
		<TransitionGroup class="gameBoard_layout" name="layoutAnimation" tag="div">
			<div v-for="(card, i) in playerCards.cards" :key="card.cardId"
				class="gameBoard_layout_stack gameBoard_layout_stack_own" :style="`left: ${(i - (12 / 2)) * 100}px;`">
				<card @click="toggleCardSelection(card)" :card="card" />
			</div>
			<div v-for="(card, i) in gameStore.selectedStack.cards" :key="card.cardId"
				class="gameBoard_layout_stack gameBoard_layout_stack_selected"
				:style="`left: ${(i - (12 / 2)) * 100}px;`">
				<card @click="toggleCardSelection(card)" :card="card" />
			</div>
			<template v-for="(player, i) in gameStore.otherPlayerCards">
				<div v-for="(card, j) in player.stack.cards" :key="card.cardId"
					class="gameBoard_layout_stack gameBoard_layout_stack_other"
					:style="`top: ${50 * i}px; left: ${j * 50}px;`">
					<card :card="card" />
				</div>
			</template>
			<template v-for="(playedStack, i) in gameStore.game.openStack">
				<div v-for="(card, j) in playedStack.cards" :key="card.cardId"
					class="gameBoard_layout_stack gameBoard_layout_stack_played"
					:style="`top: ${60 * i}px; left: ${j * 110}px;`">
					<card :card="card" />
				</div>
			</template>
		</TransitionGroup>
	</div>
</template>

<script lang="ts">
import GameApi from '~/services/apis/gameApi'
import type { Card } from '~/domain/models/Card';
import type { CardPosition } from '~/domain/models/gameBoard/CardPosition';
import type { Move, MoveResult } from '~/domain/models/Move';
import { Stack } from '~/domain/models/Stack';

export default {
	data() {
		return {
			gameStore: useGameStore(),
			arrayDimensions: 20 as number,
			array: [] as Array<CardPosition>,
			moveResult: {} as MoveResult,
			playerCards: new Stack([]),
		}
	},
	methods: {
		isCardSelected(card: Card | null): boolean { return card == null ? false : this.gameStore.selectedStack!.cards.includes(card!) },
		toggleCardSelection(card: Card | null) {
			if (card == null) return
			if (this.gameStore.selectedStack.cards.includes(card)) {
				this.gameStore.selectedStack.cards = this.gameStore.selectedStack.cards.filter(c => c !== card)
				this.playerCards.cards.push(card)
			}
			else {
				this.playerCards.cards = this.playerCards.cards.filter(c => c !== card)
				this.gameStore.selectedStack.cards.push(card)
			}
		},
		async makeMove() {
			var move: Move = {
				gameId: this.gameStore.game.gameId,
				playerId: this.gameStore.playerId,
				stack: this.gameStore.selectedStack
			}
			await GameApi.SubmitMove(move)
		}
	},
	mounted() {
		this.playerCards = this.gameStore.getCurrentPlayerStack
	},
}
</script>

<style lang="scss">
.gameBoard {
	position: absolute;
	top: 0;
	left: 0;
	width: 100dvw;
	height: 100dvh;
	overflow-y: hidden;
	overflow-x: hidden;

	&_layout {
		height: 100%;
		width: 100%;

		&_stack {
			position: absolute;
			right: 0;
			width: min-content;
			height: min-content;
			margin: 0 auto;
			background-color: #ffffff00;
			transition: all 0.1s ease-in-out;

			&_own {

				bottom: 10px;
			}

			&_selected {
				bottom: 150px;
			}

			&_other {
				display: flex;
				left: 0;
				margin: 0;
			}

			&_played {
				left: 50px;
			}

			&:hover {
				background-color: #ffffffff;
				z-index: 1;
				padding-bottom: 10px;
			}
		}
	}
}

.controllInterface {
	position: absolute;
	bottom: 10px;
	right: 10px;
}

.layoutAnimation-move,
.layoutAnimation-enter-active,
.layoutAnimation-leave-active {
	transition: all 0.5s ease-in-out;
}

.layoutAnimation-enter-from,
.layoutAnimation-leave-to {
	opacity: 0;
	transform: translateY(160%);
}

.layoutAnimation-leave-active {
	position: absolute;
}
</style>