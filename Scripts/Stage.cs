using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using static Enums;
using static Godot.Tween;

public partial class Stage : Control
{
	private List<Character> characters;
	private Dictionary<StagePosition, Sprite2D> stage;
	private Dictionary<StagePosition, Vector2> originalPositions;
	private InkCommandsManager cmdManager;

	public override void _Ready()
	{
		cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");
		var inkManager = GetNode<InkHandler>("%InkScriptManager");

		cmdManager.SpriteAppeared += (string characterTag, string spriteTag, string position) => ShowCharacterAtPosition(characterTag, spriteTag, position);
		cmdManager.SpritesWereCleared += HideAllCharacters;
		cmdManager.ScreenCleared += HideAllCharacters;
		cmdManager.SpriteWasZoomedIn += (string position) => ZoomPosition(position);
		cmdManager.SpriteWasZoomedOut += (string position) => ResetZoom(position);
		cmdManager.SpriteWasMoved += (string characterTag, string spriteTag, string positionFrom, string positionTo) => MoveSprite(characterTag, spriteTag, positionFrom, positionTo);
		inkManager.InkSceneChanged += HideAllCharacters;

		stage = new Dictionary<StagePosition, Sprite2D>()
		{
			{ StagePosition.Left, GetNode<Sprite2D>("Left") },
			{ StagePosition.Middle, GetNode<Sprite2D>("Middle") },
			{ StagePosition.Right, GetNode<Sprite2D>("Right") }
		};

		originalPositions = new Dictionary<StagePosition, Vector2>()
		{
			{ StagePosition.Left, GetNode<Sprite2D>("Left").Position },
			{ StagePosition.Middle, GetNode<Sprite2D>("Middle").Position },
			{ StagePosition.Right, GetNode<Sprite2D>("Right").Position },
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
					{ "home_shock", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_shock.png") },
					{ "home_injured", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_home_injured.png") },

					{ "army_smile", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_army_smile.png") },
					{ "army_tired", GD.Load<Texture2D>($"res://Art/Sprites/Ronan/ronan_army_tired.png") }
				}
			},
			new Character()
			{
				Id = "rikki",
				Sprites = new Dictionary<string, Texture2D>()
				{
					{ "neutral", GD.Load<Texture2D>($"res://Art/Sprites/Rikki/rikki_neutral.png") },
					{ "curious", GD.Load<Texture2D>($"res://Art/Sprites/Rikki/rikki_curious.png") },
				}
			}
		};

		if(!string.IsNullOrWhiteSpace(SaveManager.StageLeft.Item1))
		{
			ShowCharacterAtPosition(SaveManager.StageLeft.Item1, SaveManager.StageLeft.Item2, "Left");
		}

		if(!string.IsNullOrWhiteSpace(SaveManager.StageMiddle.Item1))
		{
			ShowCharacterAtPosition(SaveManager.StageMiddle.Item1, SaveManager.StageMiddle.Item2, "Middle");
		}

		if(!string.IsNullOrWhiteSpace(SaveManager.StageRight.Item1))
		{
			ShowCharacterAtPosition(SaveManager.StageRight.Item1, SaveManager.StageRight.Item2, "Right");
		}
	}

	private void ShowCharacterAtPosition(string characterTag, string spriteTag, string position)
	{
		Enum.TryParse(position, true, out StagePosition pos);

		var character = characters.Where(c => c.Id == characterTag).First();

		stage[pos].Texture = character.Sprites[spriteTag];

		switch(position.ToLower())
		{
			case "left":
				SaveManager.StageLeft = (characterTag, spriteTag);
				break;

			case "middle":
				SaveManager.StageMiddle = (characterTag, spriteTag);
				break;

			case "right":
				SaveManager.StageRight = (characterTag, spriteTag);
				break;
		}
	}

	private void HideAllCharacters()
	{
		stage[StagePosition.Left].Texture = null;
		stage[StagePosition.Middle].Texture = null;
		stage[StagePosition.Right].Texture = null;

		stage[StagePosition.Left].Position = originalPositions[StagePosition.Left];
		stage[StagePosition.Middle].Position = originalPositions[StagePosition.Middle];
		stage[StagePosition.Right].Position = originalPositions[StagePosition.Right];
	}

	private void ZoomPosition(string pos)
	{
		Enum.TryParse(pos, true, out StagePosition position);

		stage[position].Scale = new Vector2(1, 1);
	}

	private void ResetZoom(string pos)
	{
		Enum.TryParse(pos, true, out StagePosition position);

		stage[position].Scale = new Vector2(0.5f, 0.5f);
	}

	private void MoveSprite(string characterTag, string spriteTag, string positionFrom, string positionTo)
	{
		Enum.TryParse(positionFrom, true, out StagePosition pos1);
		Enum.TryParse(positionTo, true, out StagePosition pos2);

		var character = characters.Where(c => c.Id == characterTag).First();

		stage[pos1].Texture = character.Sprites[spriteTag];

		var tween = CreateTween().SetEase(EaseType.InOut);

		tween.TweenProperty(stage[pos1], "position:x", stage[pos2].Position.X, 0.5f);
	}
}
