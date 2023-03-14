using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using static Enums;

public partial class Stage : Control
{
	private List<Character> characters;
	private Dictionary<StagePosition, TextureRect> stage;

	public override void _Ready()
	{
		stage = new Dictionary<StagePosition, TextureRect>()
		{
			{ StagePosition.Left, GetNode<TextureRect>("Left") },
			{ StagePosition.Middle, GetNode<TextureRect>("Middle") },
			{ StagePosition.Right, GetNode<TextureRect>("Right") }
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
					{ "home_tired", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_tired.png") }
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
}
