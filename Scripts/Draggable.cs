using Godot;
using System;

public partial class Draggable : StaticBody2D
{
	bool isDraggable = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsMouseButtonPressed(MouseButton.Left) && isDraggable)
		{
			this.Position = GetNode<Camera2D>("Camera2D").GetViewport().GetMousePosition();
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

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }


}
