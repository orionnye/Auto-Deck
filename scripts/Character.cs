using Godot;
using System;

public partial class Character : Node3D
{
	[Export] int hp{get; set;}
	[Export] int mp{get; set;}

	// Deck
	public Deck deck = new Deck();
	public Pile draw;
	public Pile hand;
	public Pile healthPool = new Pile();

	// semi-temporary timeout function 
	public double maxTime = 1;
	private double time = 0;
	// double-temporary timeout function
	public double maxEvokeTime = 0.2;
	private double evokeTime = 0;

	// Cosmetics and Display
	public MeshInstance3D mesh = new MeshInstance3D{
		Mesh = new SphereMesh()
	};

	// --------------------------MAKE ALL ACTIONS BE CALLED FROM CHARACTER---------------

	// --------------------------ADD UI--------------------
	// -------########### UI Bonus ######### alter position on deck to follow a ray traced location
	// from camera to character mesh -----------------------
	// Could be done with no ray tracing, add cards to empty 3D node and make node face camera


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// stat access
		draw = deck.draw;
		hand = deck.hand;

		// Deck Loading
		AddChild(deck);
		
		healthPool.Position = new Vector3(-0.1f, 0.5f, 0);
		healthPool.offset = new Vector3(1f, 0f, 0);
		healthPool.Scale = new Vector3(0.2f, 0.2f, 0.2f);
		healthPool.addCardType("health", 5);
		AddChild(healthPool);

		// Visual
		mesh.Position = new Vector3(0, 0, -1);
		AddChild(mesh);
	}

	// Create a function for retrieving random Target of caster
	public Character findFoe() {
		// find parent of character, should be empty "team" node
		Node3D team = GetParent<Node3D>();
		Battle battle = team.GetParent<Battle>();

		// return value
		Character foe = null;
		// then find one more parent and compare to pick a random team node that is not caster team
		foreach (Node3D item in battle.GetChildren()) {
			// then select random child in the enemyTeam node
			// Not Random RN but --------WILL FIX LATER-------------
			if (item != team && item.GetChildCount() != 0) {
				foe = (Character)item.GetChildren()[0];
			}
		};
		// return that character, else: null
		return foe;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (healthPool.GetChildCount() <= 0) {

			this._ExitTree();
			this.GetParent().RemoveChild(this);
		}
		if (evokeTime >= maxEvokeTime) {
			evokeTime = 0;
			if (deck.hand.GetChildren().Count >= 0) {
				// GD.Print("emptying hand into draw");
				deck.castHand(this);
			} else {
				GD.Print("Empty Evocation");
			}
		}
		else {
			evokeTime += delta;
		}
		if (time >= maxTime) {
			time = 0;
			if (draw.GetChildren().Count != 0) {
				// GD.Print("migrating card into hand");
				draw.migrateCardTo(draw.getBottomCard(), hand);
			}
		}
		else {
			time += delta;
		}
	}
}
