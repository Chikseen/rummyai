import type { Card } from "../Card";

export class CardPosition {
	card: Card | null
	index: number

	public constructor(
		card: Card | null,
		index: number) {
		this.card = card;
		this.index = index;
	}
}