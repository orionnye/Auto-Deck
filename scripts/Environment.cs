using Godot;
using Godot.Collections;

public partial class Environment : Node3D
{
	public Vector3 dimensions = new Vector3(1, 1, 1);
	// public NoiseChunk[] boxes = new Array();
	// public Vector3 dimensions = new Vector3(1, 1, 1);
	public Vector3 wallDim = new Vector3(10, 10, 0.2f);
	public Vector3 floorDim = new Vector3(10, 0.3f, 10);


	public NoiseChunk addNoiseCube(Vector3 location) {
		NoiseChunk cube = new NoiseChunk{
			Position = location,
		};
		return cube;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NoiseChunk noiseWall = new NoiseChunk{
			Position = new Vector3(0, 2, -5),
			RotationCap = new Vector3(0, 0, 0),
			Dimension = new Vector3(2, 2, 0.2f),
			Density = 10,
			MeshPreset = new MeshInstance3D{
				Mesh = new SphereMesh(),
				MaterialOverlay = new StandardMaterial3D{
					AlbedoColor = new Color(0.3f, 0.3f, 0.5f)
				},
				Scale = new Vector3(2, 2, 2)
			}
		};
		AddChild(noiseWall);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
