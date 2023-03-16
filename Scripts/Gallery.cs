using Godot;
using System;

public partial class Gallery : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("BackButton").Pressed += QueueFree;
		GetNode<TextureButton>("%KaedeButton").Pressed += DisplayKaede;
	}

	public void DisplayKaede()
	{
		GetNode<Sprite2D>("Left").Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_neutral.png");
		GetNode<Sprite2D>("Right").Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_smile.png");
	}
}
