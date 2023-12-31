using Godot;
using System;


public partial class Spawner : Node2D
{
	[Export] string resource;
	[Export] float radius;
	[Export] int quantity;
	[Export] Color myColor;
	//int existent = 0;
	PackedScene packed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		packed = GD.Load<PackedScene>(resource);
	}

	public void Run(bool isToggledOn)
	{
		Timer myTimer = GetChild<Timer>(0);
		//existent = 0;
		if(isToggledOn) myTimer.Start();
		else myTimer.Stop();
	}

	public void Spawn()
	{
		//if (existent >= quantity) return;
		RigidBody2D item = packed.Instantiate() as RigidBody2D;
		AddChild(item);
		item.GlobalPosition = this.GlobalPosition + new Vector2(x(GD.RandRange(-1, 1)), y(GD.RandRange(0, 1)));
		item.GetChild<Polygon2D>(0).Color = myColor;
		//existent++;
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
