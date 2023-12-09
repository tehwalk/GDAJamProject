using Godot;
using System;

public partial class Draggable : Area2D
{
	bool isDraggable = false;
	Vector2 pos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsMouseButtonPressed(MouseButton.Left) && isDraggable)
		{
			this.Position = GetGlobalMousePosition();
		} 

		if(Input.IsActionJustPressed("Click") && isDraggable)
		{
			this.Rotation += Mathf.DegToRad(90f);
		} 
	}


	public void OnMouseEntered()
	{
		isDraggable = true;
	}

	public void OnMouseExited()
	{
		isDraggable = false;
	}

   /*  public override void _Input(InputEvent @event)
	{
	   if(@event is InputEventMouseButton eventMouse && isDraggable)
	   {
			pos = GetLocalMousePosition()
	   }
	} */


}
