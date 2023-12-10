using Godot;
using System;

public partial class Draggable : Area2D
{
	[Export] float rotationDegrees;
	bool isDraggable = false;
	Vector2 pos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Click") && isDraggable)
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
		isDraggable = true;
	}

	public void OnMouseExited()
	{
		isDraggable = false;
	}

}
