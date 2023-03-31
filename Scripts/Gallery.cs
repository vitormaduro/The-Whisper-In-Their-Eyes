using Godot;
using System;
using System.Collections.Generic;

public partial class Gallery : Control
{
	private Sprite2D left;
	private Sprite2D right;
	private TextureRect polaroid;
	private AnimatedSprite2D banner;
	private List<GalleryButton> buttons;
	private TabBar tabBar;

	public override void _Ready()
	{
		left = GetNode<Sprite2D>("Left");
		right = GetNode<Sprite2D>("Right");
		polaroid = GetNode<TextureRect>("Polaroid");
		banner = GetNode<AnimatedSprite2D>("Banner");
		tabBar = GetNode<TabBar>("TabBar");

		left.TextureChanged += () => { left.Scale = new Vector2(0.5f, 0.5f); };
		right.TextureChanged += () => { right.Scale = new Vector2(0.5f, 0.5f); };
		tabBar.TabChanged += (long tabId) => ChangeTab(tabId);

		buttons = new List<GalleryButton>()
		{
			new GalleryButton()
			{
				TabId = 0,
				Button = GetNode<TextureButton>("%KaedeButton"),
				Action = () => DisplayKaede()
			},
			new GalleryButton()
			{
				TabId = 0,
				Button = GetNode<TextureButton>("%RonanButton"),
				Action = () => DisplayRonan()
			},
			new GalleryButton()
			{
				TabId = 0,
				Button = GetNode<TextureButton>("%RikkiButton"),
				Action = () => DisplayRikki()
			},
			new GalleryButton()
			{
				TabId = 1,
				Button = GetNode<TextureButton>("%Photo1Button"),
				Action = () => DisplayPolaroid(1)
			},
			new GalleryButton()
			{
				TabId = 1,
				Button = GetNode<TextureButton>("%Photo2Button"),
				Action = () => DisplayPolaroid(2)
			},
			new GalleryButton()
			{
				TabId = 1,
				Button = GetNode<TextureButton>("%Photo3Button"),
				Action = () => DisplayPolaroid(3)
			},
			new GalleryButton()
			{
				TabId = 1,
				Button = GetNode<TextureButton>("%Photo4Button"),
				Action = () => DisplayPolaroid(4)
			},
			new GalleryButton()
			{
				TabId = 1,
				Button = GetNode<TextureButton>("%BannerButton"),
				Action = () => DisplayBanner()
			},
			new GalleryButton()
			{
				TabId = 2,
				Button = GetNode<TextureButton>("%Bedroom1Button"),
				Action = () => DisplayBg("bedroom1")
			},
			new GalleryButton()
			{
				TabId = 2,
				Button = GetNode<TextureButton>("%Bedroom2Button"),
				Action = () => DisplayBg("bedroom2")
			},
			new GalleryButton()
			{
				TabId = 2,
				Button = GetNode<TextureButton>("%LivingRoomButton"),
				Action = () => DisplayBg("living_room")
			},
			new GalleryButton()
			{
				TabId = 2,
				Button = GetNode<TextureButton>("%OfficeButton"),
				Action = () => DisplayBg("office")
			}
		};

		GetNode<TextureButton>("BackButton").Pressed += QueueFree;

		left.Visible = right.Visible = polaroid.Visible = banner.Visible = false;

		buttons.ForEach(b => b.Button.Pressed += b.Action);

		ChangeTab(0);
	}

	private void ChangeTab(long tabId)
	{
		buttons.ForEach(b => b.Button.Visible = b.TabId == tabId);
	}

	private void DisplayKaede()
	{
		polaroid.Visible = banner.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_neutral.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Kaede/kaede_smile.png");
	}

	private void DisplayRonan()
	{
		polaroid.Visible = banner.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_army_smile.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Ronan/ronan_home_smile.png");
	}

	private void DisplayRikki()
	{
		polaroid.Visible = banner.Visible = false;
		left.Visible = right.Visible = true;
		left.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_curious.png");
		right.Texture = GD.Load<Texture2D>("res://Art/Sprites/Rikki/rikki_neutral.png");
	}

	private void DisplayPolaroid(int version)
	{
		left.Visible = right.Visible = banner.Visible = false;
		polaroid.Visible = true;
		polaroid.Texture = GD.Load<Texture2D>($"res://Art/CGs/photo{version}_color.png");
	}

	private void DisplayBanner()
	{
		left.Visible = right.Visible = polaroid.Visible = false;
		banner.Visible = true;
	}

	private void DisplayBg(string name)
	{
		left.Visible = right.Visible = banner.Visible = false;
		polaroid.Visible = true;
		polaroid.Texture = GD.Load<Texture2D>($"res://Art/Backgrounds/{name}.jpg");
	}
}
