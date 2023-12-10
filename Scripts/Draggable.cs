using Godot;
using System;

public partial class Draggable : Area2D
{
	public static Draggable currentDraggable;
	[Export] float rotationDegrees;
	Vector2 pos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
       currentDraggable = null;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Click") && currentDraggable == this)
		{
			this.Position = GetGlobalMousePosition();
		}
	}

	public void OnRotationClicked()
	{
		this.RotationDegrees += rotationDegrees;
	}

	public void OnMouseEntered()
	{
		if (currentDraggable == null)
		{
			currentDraggable = this;
		}
	}

	public void OnMouseExited()
	{
		if (!Input.IsActionPressed("Click") && currentDraggable == this) currentDraggable = null;
	}

}
