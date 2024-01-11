using Godot;
using System;

public partial class Grid : Node3D
{
	// public Vector3 dimensions = new Vector3(40, 20, 1);
	// public Vector3 offset = new Vector3(-15, -5, -8);

	public PackedScene godotBox = GD.Load<PackedScene>("res://scenes/Environment/blocks/godot_cube.tscn");
	public PackedScene dirtyBox = GD.Load<PackedScene>("res://scenes/Environment/blocks/dirtyCube.tscn");
	public void addBoxes(Vector3 dim, Vector3 offset, Vector3 noise) {
		for (int x = 0; x < dim.X; x++) {
			for (int y = 0; y < dim.Y; y++) {
				for (int z = 0; z < dim.Z; z++) {
					Vector3 noiseRand = noise*GD.Randf();
					Node box = dirtyBox.Instantiate();
					box.Set("position", new Vector3(x, y, z) + offset + noiseRand);
					this.AddChild(box);
				}
			}
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		addBoxes(new Vector3(40, 20, 1), new Vector3(-15, -5, -8), new Vector3(0, 0, 1));
		addBoxes(new Vector3(40, 1, 10), new Vector3(-10, -3, -3), new Vector3(0, 0.2f, 0));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
