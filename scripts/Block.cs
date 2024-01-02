using Godot;
using Godot.Collections;
using System;
using System.Drawing;

public partial class Block : Node3D
{
	public Vector3 density;
	public Vector3 dimensions;
	public MeshInstance3D mesh = new MeshInstance3D{
		Mesh = new SphereMesh()
	};

	Vector3 randVector3(Vector3 dim) {
		return dim*new Vector3(GD.Randf(), GD.Randf(), GD.Randf());
	}
	
	public Vector3[] distribution(int amount, Vector3 dim, double deviation = 1) {
		Vector3[] points = new Vector3[amount];
		Vector3 center = dim / 2;
		for (int i = 0; i < amount; i++)
		{
			Vector3 point = center+randVector3(center);
			
			point += point * (float)deviation;
			points[i] = point;
		}
		return points;
	}

	// Need functions for population and distributions
	public void populate(int amount = 1) {
		Vector3[] points = distribution(amount, dimensions, 0.1);
		foreach (var point in points)
		{
			MeshInstance3D item = new MeshInstance3D();
			item.Mesh = mesh.Mesh;
			item.Position = point;
			AddChild(item);
		}
	}
	public override void _Ready() {
		_Ready();
		// populate(10);
	}
	public override void _Process(double delta) {
	}
}
