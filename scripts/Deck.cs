using Godot;
using System;
using System.Reflection.Metadata;

public partial class Deck : Node3D
{
	public Vector3 offset = new Vector3(0.01f, 0.01f, 0.01f);
	public Pile draw = new Pile();
	public Pile hand = new Pile();

	// semi-temporary timeout function
	public double maxTime = 1;
	private double time = 0;

	public void castHand(Character caster) {
		// is caster valid?
		// GD.Print("caster?:", caster is Character);
		// cast all cards in hand and then return them to the draw pile
		hand.useAllCards(caster);
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Scale = new Vector3(0.3f, 0.3f, 0.3f);

		hand.Position = new Vector3(1.5f, 0, 0);
		hand.offset = new Vector3(1, 0, -0.01f);
		AddChild(hand);
		draw.Position = new Vector3(-1f, -2f, 0);
		draw.offset = new Vector3(0.2f, 0.2f, -0.01f);
		AddChild(draw);
		// discard.Position = new Vector3(2, -1.5f, 0);
		// AddChild(discard);
		hand.exitPile = draw;
		draw.exitPile = hand;
		hand.addCardType("punch", 3);
		draw.addCardType("mend", 2);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// if (time >= maxTime) {
		// 	// GD.Print("timeout");
		// 	time = 0;
		// 	// draw.addCard(Library.cards["punch"].Invoke());
		// 	if (draw.GetChildren().Count == 0) {
		// 		// GD.Print("emptying hand into draw");
		// 		castHand();
		// 		// hand.migrateCardTo(hand.getTopCard(), draw);
		// 	} else {
		// 		draw.migrateCardTo(draw.getTopCard(), hand);
		// 		// GD.Print(draw.GetChildren().Count);
		// 	}
		// }
		// else {
		// 	time += delta;
		// }
	}
}
