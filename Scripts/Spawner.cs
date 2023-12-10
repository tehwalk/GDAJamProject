using Godot;
using System;


public partial class Spawner : Node2D
{
	enum DropletColor { Red, Green, Blue }
	[Export] string resource;
	[Export] float radius;
	[Export] int quantity;
	[Export] DropletColor dropletColor;
	int existent = 0;
	PackedScene packed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		packed = GD.Load<PackedScene>(resource);
	}

	public void ResetInternalTimer()
	{
		Timer myTimer = GetChild<Timer>(0);
		existent = 0;
		myTimer.Start();
	}

	public void Spawn()
	{
		if (existent >= quantity) return;
		RigidBody2D item = packed.Instantiate() as RigidBody2D;
		AddChild(item);
		item.GlobalPosition = this.GlobalPosition + new Vector2(x(GD.RandRange(-1, 1)), y(GD.RandRange(0, 1)));
		switch (dropletColor)
		{
			case DropletColor.Red:
				item.GetChild<Polygon2D>(0).Color = Colors.Red;
				break;
			case DropletColor.Green:
				item.GetChild<Polygon2D>(0).Color = Colors.Green;
				break;
			case DropletColor.Blue:
				item.GetChild<Polygon2D>(0).Color = Colors.Blue;
				break;

		}
		existent++;
	}

	float x(float t)
	{
		return Mathf.Sin(Mathf.DegToRad(t)) * radius;
	}

	float y(float t)
	{
		return Mathf.Cos(Mathf.DegToRad(t)) * radius;
	}


}
