using Godot;
using System;

public partial class NoiseChunk : Node3D
{
	// Class properties for initialization later
	public Vector3 Dimension = new Vector3(1, 1, 1);
	public Vector3 RotationCap = new Vector3((float)Math.PI, (float)Math.PI, (float)Math.PI);
	public int Density = 1;
	public MeshInstance3D MeshPreset = new MeshInstance3D{
		Mesh = new SphereMesh()
	};
	// Generates items for the noisey chunk
	public void populate(Vector3 pos, Vector3 rotCap, Vector3 dim, int density, MeshInstance3D mesh) {
		for (int i = 0; i < density; i++) {
			Vector3 noise = new Vector3(GD.Randf(), GD.Randf(), GD.Randf());
			// creation
			MeshInstance3D dupli = new MeshInstance3D{
				Mesh = MeshPreset.Mesh,
				MaterialOverlay = MeshPreset.MaterialOverlay,
				Scale = MeshPreset.Scale,
				Position = dim*noise - dim/2,
				Rotation = rotCap*noise
			};
			AddChild(dupli);
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Go french a tire iron mid-swing");
		populate(Position, RotationCap, Dimension, Density, MeshPreset);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
