using Godot;
using System;
using System.Collections.Generic;

public partial class Mixer : Area2D
{
	List<Polygon2D> dropletsInside;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dropletsInside = new List<Polygon2D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnDropletEnter(Node2D droplet)
	{
		if (droplet.HasMeta("isDroplet") && droplet.GetMeta("isDroplet").AsBool() == true)
		{
			dropletsInside.Add(droplet.GetChild<Polygon2D>(0));
			CalculateColor();
		}
	}

	public void OnDropletExit(Node2D droplet)
	{
		if (droplet.HasMeta("isDroplet") && droplet.GetMeta("isDroplet").AsBool())
			dropletsInside.Remove(droplet.GetChild<Polygon2D>(0));
	}

	void CalculateColor()
	{
		int r = 0, g = 0, b = 0;
		int dropCount = dropletsInside.Count;
		foreach (Polygon2D drop in dropletsInside)
		{
			if (drop.Color.IsEqualApprox(Colors.Red)) r++;
			else if (drop.Color.IsEqualApprox(Colors.Green)) g++;
			else if (drop.Color.IsEqualApprox(Colors.Blue)) b++;
		}
		float rRatio = (float)r / dropCount, gRatio = (float)g / dropCount, bRatio = (float)b / dropCount;
		Color myColor = new Color(rRatio, gRatio, bRatio, 1);
		//myColor = new Color(0.5f, 0.5f, 0);

		foreach (Polygon2D drop in dropletsInside)
		{
			drop.Color = myColor;
			GD.Print(myColor);
			//drop.Color = Colors.Black;
		}
		//find the ratio of colors (%)
		//mix them with the required ratio
	}

}
