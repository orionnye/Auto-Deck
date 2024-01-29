using Godot;
using System;

public partial class generator : Control
{
	public Vector2 dimensions = new Vector2(128, 128);
	public Vector2 position = new Vector2(300, 200);

	public void circuit(int input) {
		float lineWidth = 5;
		int inputLineCount = 8;

		Vector2 pos = new Vector2(200, 200);
		Vector2 boxDim = new Vector2(60, 60);
		Vector2 wireSpacing =  (dimensions - boxDim) / 2;
		Vector2 boxPos = pos + ((dimensions - boxDim) / 2);
		float wireSegmentLength = wireSpacing.X / 3;
		float startSpacing = dimensions.Y / (inputLineCount+1);
		float enterspacing = boxDim.Y / (inputLineCount + 1);

		// draw entering circuits
		for (var i = 1; i <= inputLineCount; i++) {
			Vector2 iStart = new Vector2(0, startSpacing*i)+pos;
			Vector2 iEnd = new Vector2(0, enterspacing*i)+boxPos;
			Vector2 iAngle = iStart + new Vector2(wireSegmentLength, 0);
			Vector2 iAngleEnd = iEnd + new Vector2(-wireSegmentLength, 0);
			// wireStart
			DrawLine(iStart, iAngle, Colors.Black, lineWidth);
			// wireAngle
			DrawLine(iAngle, iAngleEnd, Colors.Black, lineWidth);
			// // wireEnter
			DrawLine(iAngleEnd, iEnd, Colors.Black, lineWidth);
		}
		// draw exit circuits
		for (var i = 1; i <= inputLineCount; i++) {
			Vector2 iStart = new Vector2(dimensions.X, startSpacing*i)+pos;
			Vector2 iEnd = new Vector2(boxDim.X, enterspacing*i)+boxPos;
			Vector2 iAngle = iStart + new Vector2(-wireSegmentLength, 0);
			Vector2 iAngleEnd = iEnd + new Vector2(+wireSegmentLength, 0);
			// wireStart
			DrawLine(iStart, iAngle, Colors.Black, lineWidth);
			// wireAngle
			DrawLine(iAngle, iAngleEnd, Colors.Black, lineWidth);
			// // wireEnter
			DrawLine(iAngleEnd, iEnd, Colors.Black, lineWidth);
		}
		// draw the mutation box
		DrawRect(new Rect2(boxPos.X, boxPos.Y, boxDim.X, boxDim.Y), Colors.Red);
		DrawRect(new Rect2(pos.X, pos.Y, dimensions.X, dimensions.Y), Colors.Black, false);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Draw()
	{
		circuit(5);
		// DrawLine(new Vector2(30, 50), new Vector2(50, 50), Colors.Green, 5);
		// DrawRect(new Rect2(40, 30, 10, 10), Colors.Green);
		// DrawRect(new Rect2(5.5f, 1.5f, 2.0f, 2.0f), Colors.Green, false, 1.0f);
		// DrawLine(new Vector2(4.0f, 1.0f), new Vector2(4.0f, 4.0f), Colors.Green, 2.0f);
		// DrawLine(new Vector2(7.5f, 1.0f), new Vector2(7.5f, 4.0f), Colors.Green, 3.0f);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
