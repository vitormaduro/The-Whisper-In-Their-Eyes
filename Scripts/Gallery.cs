using Godot;
using System;

public partial class Gallery : Control
{
	private Sprite2D left;
	private Sprite2D right;

	public override void _Ready()
	{
		left = GetNode<Sprite2D>("Left");
		right = GetNode<Sprite2D>("Right");

		left.TextureChanged += () => { left.Scale = new Vector2(0.5f, 0.5f); };
		right.TextureChanged += () => { right.Scale = new Vector2(0.5f, 0.5f); };

		GetNode<TextureButton>("BackButton").Pressed += QueueFree;
		GetNode<TextureButton>("%KaedeButton").Pressed += DisplayKaede;
		GetNode<TextureButton>("%RonanButton").Pressed += DisplayRonan;
		GetNode<TextureButton>("%RikkiButton").Pressed += DisplayRikki;
	}

	public void DisplayKaede()
	{
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_neutral.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_smile.png");
	}

	public void DisplayRonan()
	{
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_army_smile.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_home_smile.png");
	}

	public void DisplayRikki()
	{
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_curious.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_neutral.png");
	}
}
