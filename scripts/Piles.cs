using Godot;
using System;
using System.Linq;

public partial class Pile : Node3D
{
	// Malleable stats
	[Export] public Vector3 offset = new Vector3(0.01f, 0.01f, 0.01f);
	[Export] public Vector3 dimensions = new Vector3(75, 100, 0);
	[Export] int startCount = 0;
	[Export] int maxCards = 10;
	[Export] public bool visiblePileMarker = true;
	[Export] public double cardCorrectionSpeed = 0.5;

	[Export] public Pile exitPile = null;


	public void addCard(Card card) {
		if (card is Card) {
			// gotta find index of addition
			AddChild(card);
			foreach (Card child in GetChildren()) {
				int index = GetChildren().IndexOf(child);
				Vector3 indexedPos = offset*index;
				// GD.Print("Testing index of fresh card: ", index);
				child.Position = indexedPos;
			}
		}
	}
	public void addCardType(string name, int count = 1) {
		for (int i = 0; i < count; i++) {
			Card card = Library.cards[name].Invoke();
			addCard(card);
		}
	}
	public void migrateCardTo(Card card, Pile pile) {
		if (card != null) {
			// Store current meshPosition and reset once card is migrated
			Vector3 meshOffset = card.GlobalPosition;
			// Remove card from self and add card to target Pile
			RemoveChild(card);
			pile.addCard(card);
			card.mesh.GlobalPosition = meshOffset;
		}
	}
	public void migrateAllCardsTo(Pile pile) {
		foreach (Card card in GetChildren())
		{
			// GD.Print("card: ", card);
			migrateCardTo(card, pile);
		}
	}
	// public void useCard(Card card, Pile pile) {
	// 	// Take wisdom scaling into account for multiple casts
	// 	card.evoke();
	// 	migrateCardTo(card, pile);
	// }
	public void useTopCard(Character caster) {
		Card card = getTopCard();
		//---------------------USE CARD-------------------------
		card.evoke(caster);
		//-----------Cycle card into next pile---------------
		if (exitPile != null) {
			migrateCardTo(card, exitPile);
		} else {
			GD.Print("exhausting card");
			card._ExitTree();
			card.GetParent().RemoveChild(card);
		}
	}
	public void useCards(Character caster, int amount, bool exhaust = false) {
		for (int i = 0; i < amount; i++) {
			useTopCard(caster);
		}
	}

	public void useAllCards(Character caster) {
		foreach (Card card in GetChildren())
		{
			card.evoke(caster);
			if (exitPile != null) {
				migrateCardTo(card, exitPile);
			}
		}
	}
	public Card getTopCard() {
		// Find count of Array
		var children = GetChildren();
		int count = children.Count;
		if (count > 0) {
			// retrieve the last Card, should be the top card
			return children[count-1] as Card;
		}
		return null;
	}
	public Card getBottomCard() {
		// retrieve the first Card, should be the bottom card
		return GetChildren()[0] as Card;
	}
	public override void _Ready()
	{
		
	}
	public override void _Process(double delta)
	{

	}
}
