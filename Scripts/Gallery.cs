using Godot;
using System;

public partial class Gallery : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("BackButton").Pressed += QueueFree;
	}
}
