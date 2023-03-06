using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class Stage : Control
{
	private List<Character> characters;

	public override void _Ready()
	{
		var res = "res:/";

		characters = new List<Character>()
		{
			new Character() {
				Id = "kaede",
				Sprites = new Dictionary<string, Texture2D>()
				{
					{ "smiling",  GD.Load<Texture2D>($"{res}/Art/Sprites/Kaede/kaede.png") }
				}
			},
		};
	}

	public void ShowCharacterAtPosition(string characterTag, string spriteTag, string position)
	{
		var pos = position switch
		{
			"left" => GetNode<TextureRect>("Left"),
			"middle" => GetNode<TextureRect>("Middle"),
			_ => GetNode<TextureRect>("Right"),
		};

		var character = characters.Where(c => c.Id == characterTag).First();

		pos.Texture = character.Sprites[spriteTag];
	}
}
