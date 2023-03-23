using Godot;
using System;

public partial class Gallery : Control
{
	private Sprite2D left;
	private Sprite2D right;
	private TextureRect polaroid;

	public override void _Ready()
	{
		left = GetNode<Sprite2D>("Left");
		right = GetNode<Sprite2D>("Right");
		polaroid = GetNode<TextureRect>("Polaroid");

		left.TextureChanged += () => { left.Scale = new Vector2(0.5f, 0.5f); };
		right.TextureChanged += () => { right.Scale = new Vector2(0.5f, 0.5f); };

		GetNode<TextureButton>("BackButton").Pressed += QueueFree;
		GetNode<TextureButton>("%KaedeButton").Pressed += DisplayKaede;
		GetNode<TextureButton>("%RonanButton").Pressed += DisplayRonan;
		GetNode<TextureButton>("%RikkiButton").Pressed += DisplayRikki;
		GetNode<TextureButton>("%Photo1Button").Pressed += () => DisplayPolaroid(1);
		GetNode<TextureButton>("%Photo2Button").Pressed += () => DisplayPolaroid(2);
		GetNode<TextureButton>("%Photo3Button").Pressed += () => DisplayPolaroid(3);
		GetNode<TextureButton>("%Photo4Button").Pressed += () => DisplayPolaroid(4);

		left.Visible = right.Visible = polaroid.Visible = false;
	}

	private void DisplayKaede()
	{
		polaroid.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_neutral.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_smile.png");
	}

	private void DisplayRonan()
	{
		polaroid.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_army_smile.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_home_smile.png");
	}

	private void DisplayRikki()
	{
		polaroid.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_curious.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_neutral.png");
	}

	private void DisplayPolaroid(int version)
	{
		left.Visible = right.Visible = false;
		polaroid.Visible = true;
		polaroid.Texture = GD.Load<Texture2D>($"res://Art/CGs/photo{version}_color.png");
	}
}
