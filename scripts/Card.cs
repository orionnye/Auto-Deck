using Godot;
using System;
using System.Linq;

public partial class Card : Node3D
{
	// Impact Stats
	[Export] int baseDamage{get; set;}
	[Export] int baseHeal{get; set;}

	// Scalars
	// Ayo, that's a good stat name
	[Export] double conScalar{get; set;}
	[Export] double strScalar{get; set;}
	[Export] double dexScalar{get; set;}
	[Export] double wisScalar{get; set;}
	[Export] double intScalar{get; set;}
	[Export] double rizScalar{get; set;}
	
	// Delegates to have functions assigned to them later
	public Action passive;
	public Card self;
	public Action<Battle, Character> cast;
	// Cosmetics and Display
	public MeshInstance3D mesh = new MeshInstance3D();

	private T FindCaster<T>(Node node) where T : Node
	{
		if (node == null)
		{
			// Invalid parameter
			return null;
		}
		if (node is T)
		{
			// Found the first parent of the desired class
			return (T)node;
		}

		// Move up to the parent node and continue searching
		return FindCaster<T>(node.GetParent());
	}

	public void evoke(Character caster) {
		// Access the global scene tree
		SceneTree sceneTree = GetTree();
		// Access the root node of the scene tree (global root)
		Node rootNode = sceneTree.Root;
		// Access a specific node in the scene tree
		var battleNode = (Battle)caster.GetParent().GetParent();

		// GD.Print("NodePosition: ", battleNode.apple);
		cast(battleNode, caster);
	}
	private void correctPos() {
		// Vector3 meshOffset = mesh.Position;
		mesh.Position = mesh.Position.Lerp(new Vector3(0, 0, 0), 0.1f);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		self = this;
		mesh.Mesh = new BoxMesh();
		mesh.Scale = new Vector3(0.7f, 1, 0.1f);
		AddChild(mesh);
		// GD.Print("Go Fuck yourself!");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		correctPos();
		if (passive != null) {
			passive();
		}
	}
}
