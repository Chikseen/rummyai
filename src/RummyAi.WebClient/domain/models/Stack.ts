import type { Card } from "./Card";

export class Stack {
	cards: Card[]

	public constructor(
		cards: Card[]) {
		this.cards = cards;
	}
}