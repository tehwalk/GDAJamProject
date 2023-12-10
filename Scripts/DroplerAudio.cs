using Godot;
using System;

public partial class DroplerAudio : AudioStreamPlayer2D
{
	[Export] AudioStream[] sounds;
	public void PlayRandomSound(Node body)
	{
	   GD.Print("re");
	   Stream = sounds[GD.RandRange(0, sounds.Length)];
       Play();
	}
}
