using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using static Enums;

public partial class Stage : Control
{
	private List<Character> characters;
	private Dictionary<StagePosition, Sprite2D> stage;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		cmdManager.SpriteAppeared += (string characterTag, string spriteTag, string position) => ShowCharacterAtPosition(characterTag, spriteTag, position);
		cmdManager.SpritesWereCleared += HideAllCharacters;
		cmdManager.ScreenCleared += HideAllCharacters;
		cmdManager.SpriteWasZoomedIn += (string position, string pivotX, string pivotY) => ZoomPositionToPoint(position, pivotX, pivotY);
		cmdManager.SpriteWasZoomedOut += (string position) => ResetZoom(position);

		stage = new Dictionary<StagePosition, Sprite2D>()
		{
			{ StagePosition.Left, GetNode<Sprite2D>("Left") },
			{ StagePosition.Middle, GetNode<Sprite2D>("Middle") },
			{ StagePosition.Right, GetNode<Sprite2D>("Right") }
		};

		characters = new List<Character>()
		{
			new Character() {
				Id = "kaede",
				Sprites = new Dictionary<string, Texture2D>()
				{
					{ "neutral",  GD.Load<Texture2D>($"res://Art/Sprites/Kaede/kaede_neutral.png") },
					{ "scared",  GD.Load<Texture2D>($"res://Art/Sprites/Kaede/kaede_scared.png") },
					{ "sick",  GD.Load<Texture2D>($"res://Art/Sprites/Kaede/kaede_sick.png") },
					{ "smile",  GD.Load<Texture2D>($"res://Art/Sprites/Kaede/kaede_smile.png") }
				}
			},
			new Character()
			{
				Id = "ronan",
				Sprites = new Dictionary<string, Texture2D>()
				{
					{ "home_neutral", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_neutral.png") },
					{ "home_smile", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_smile.png") },
					{ "home_tired", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_tired.png") },

					{ "army_neutral", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_neutral.png") },
					{ "army_smile", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_army_smile.png") },
					{ "army_tired", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_army_pokertired.png") },
					{ "army_serious", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_tired.png") },
				}
			},
			new Character()
			{
				Id = "rikki",
				Sprites = new Dictionary<string, Texture2D>()
				{
					{ "neutral", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_neutral.png") },
					{ "smile", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_smile.png") },
					{ "tired", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_tired.png") }
				}
			}
		};
	}

	public void ShowCharacterAtPosition(string characterTag, string spriteTag, string position)
	{
		Enum.TryParse(position, true, out StagePosition pos);

		var character = characters.Where(c => c.Id == characterTag).First();

		stage[pos].Texture = character.Sprites[spriteTag];
	}

	public void HideAllCharacters()
	{
		stage[StagePosition.Left].Texture = null;
		stage[StagePosition.Middle].Texture = null;
		stage[StagePosition.Right].Texture = null;
	}

	public void ZoomPositionToPoint(string pos, string pivotX, string pivotY)
	{
		Enum.TryParse(pos, true, out StagePosition position);
		var x = float.Parse(pivotX);
		var y = float.Parse(pivotY);

		stage[position].Offset = new Vector2(x, y);
		stage[position].Scale = new Vector2(1, 1);
	}

	public void ResetZoom(string pos)
	{
		Enum.TryParse(pos, true, out StagePosition position);

		stage[position].Scale = new Vector2(0.5f, 0.5f);
	}
}
