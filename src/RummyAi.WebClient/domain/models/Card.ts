export class Card {
	suit: number
	rank: number
	cardId: string

	public constructor(
		suit: number,
		rank: number,
		cardId: string) {
		this.suit = suit;
		this.rank = rank;
		this.cardId = cardId;
	}
}