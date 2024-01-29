using Godot;
using System;


public partial class Battle : Node3D
{
	public int apple = 0;
	public PackedScene characterScene = GD.Load<PackedScene>("res://scenes/Characters/Character.tscn");
	public Node3D teamA = new Node3D();
	public Node3D teamB = new Node3D();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// ------------------CREATE ENVIRONMENT CLASS------------------
		// this should handle a selection of construction types

		// Environment
		// NoiseChunk noiseWall = new NoiseChunk{
		// 	Position = new Vector3(0, 2, -5),
		// 	RotationCap = new Vector3(0, 0, 0),
		// 	Dimension = new Vector3(15, 10, 0.2f),
		// 	Density = 20,
		// 	MeshPreset = new MeshInstance3D{
		// 		Mesh = new SphereMesh(),
		// 		MaterialOverlay = new StandardMaterial3D{
		// 			AlbedoColor = new Color(0.3f, 0.3f, 0.5f)
		// 		},
		// 		Scale = new Vector3(2, 2, 2)
		// 	}
		// };
		// NoiseChunk noiseFloor = new NoiseChunk{
		// 	Position = new Vector3(0, -3, -1),
		// 	Rotation = new Vector3(0.1f, 0, 0),
		// 	RotationCap = new Vector3(0, 0.01f, 0.01f),
		// 	Dimension = new Vector3(15, 0.1f, 8),
		// 	Density = 10,
		// 	MeshPreset = new MeshInstance3D{
		// 		Mesh = new BoxMesh(),
		// 		MaterialOverlay = new StandardMaterial3D{
		// 			AlbedoColor = new Color(0.2f, 0.2f, 0.2f)
		// 		},
		// 		Scale = new Vector3(2, 1, 2)
		// 	}
		// };
		// AddChild(noiseWall);
		// AddChild(noiseFloor);

		// Characters Initialization
		Character bro = new Character{
			Position = new Vector3(-3, -1, -2),
			deck = new Deck(),
			maxTime = 0.5,
			maxEvokeTime = 3
		};
		bro.deck.draw.AddChild(Library.cards["godot"].Invoke());
		
		Character otherguy = (Character)characterScene.Instantiate();
		otherguy.Position = new Vector3(3, -1, -2);
		// 	mesh = new MeshInstance3D{
		// 		Mesh = new BoxMesh()
		// 	},
		// 	maxTime = 1,
		// 	maxEvokeTime = 1
		// };
		otherguy.deck.draw.AddChild(Library.cards["mend"].Invoke());
		
		AddChild(teamA);
		teamA.AddChild(bro);
		AddChild(teamB);
		teamB.AddChild(otherguy);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
