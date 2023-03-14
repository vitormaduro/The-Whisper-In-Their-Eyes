using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using GodotInk;

public partial class InkHandler : RichTextLabel
{
	[Export] private InkStory story;

	private double timer = 0f;
	private bool canType = true;
	private bool isSkipping = false;
	private Dictionary<string, Action<string[]>> commands;

	public override void _Ready()
	{
		story.ResetState();
		
		if(SaveManager.CurrentScene != null)
		{
			JumpToScene(SaveManager.CurrentScene);
		}

		InitialiseCommands();
		ContinueStory();

		base._Ready();
	}

	private void InitialiseCommands()
	{
		var res = "res:/";
		
		commands = new Dictionary<string, Action<string[]>>() 
		{
			{ 
				"change_bg", 
				(string[] args) => 
				{
					GetNode<TextureRect>("%BackgroundImage").Texture = (Texture2D) GD.Load($"{res}/Art/Backgrounds/{args[0]}.jpg");
				} 
			},
			{
				"ost_on",
				(string[] args) => 
				{
					GetNode<OstPlayer>("%OstPlayer").PlaySongByTag(args[0]);
				}
			},
			{
				"ost_off",
				(string[] args) => 
				{
					GetNode<OstPlayer>("%OstPlayer").StopSong();
				}
			},
			{
				"sprite",
				(string[] args) => 
				{
					GetNode<Stage>("%Stage").ShowCharacterAtPosition(args[0], args[1], args[2]);
				}
			},
			{
				"sfx",
				(string[] args) => 
				{
					GetNode<SfxPlayer>("%SfxPlayer").PlayEffectByTag(args[0]);
				}
			},
			{
				"clear_text",
				(string[] args) =>
				{
					this.Clear();
					this.VisibleCharacters = 0;
				}
			},
			{
				"clear_sprites",
				(string[] args) => 
				{
					GetNode<Stage>("%Stage").HideAllCharacters();
				}
			},
			{
				"disclaimer",
				(string[] args) =>
				{
					GetNode<TextureRect>("%BackgroundImage").Texture = GD.Load<Texture2D>("res://Art/Backgrounds/black.jpg");

					this.Text = Tr(args[0]);
					canType = true;
				}
			},
			{
				"clear_all",
				(string[] args) => 
				{
					this.Clear();
					this.VisibleCharacters = 0;

					GetNode<Stage>("%Stage").HideAllCharacters();
				}
			},
			{
				"screen_shake",
				(string[] args) =>
				{
					bool.TryParse(args[0], out var mode);

					var animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");

					if(mode)
					{
						animationPlayer.Play("screen_shake");
					}
					else
					{
						animationPlayer.Stop();
					}
				}
			}
		};
	}

	public override void _Process(double delta)
	{
		if(SettingsManager.IsGamePaused)
		{
			return;
		}

		isSkipping = Input.IsActionPressed("skip_text");
		timer += delta;

		if(isSkipping || canType && timer >= (1f / SettingsManager.TextSpeed))
		{
			timer = 0f;

			this.VisibleCharacters++;

			if(this.VisibleRatio == 1)
			{
				canType = false;
			}
		}

		if(isSkipping || Input.IsActionJustPressed("text_advance"))
		{
			if(canType)
			{
				this.VisibleCharacters = this.GetTotalCharacterCount();
				canType = false;
			}
			else
			{
				ContinueStory();
			}
		}
	}

	public void JumpToScene(string sceneName)
	{
		story.ChoosePathString($"Scene_{sceneName}");
	}

	private void ContinueStory()
	{
		if(!story.CanContinue)
		{
			return;
		}

		var line = story.Continue().Replace("\n", "");
		var tags = story.CurrentTags;

		if(tags.Any(t => t.StartsWith("SCENE:")))
		{
			SaveManager.CurrentScene = tags.Where(t => t.StartsWith("SCENE:")).First().Replace("SCENE:", "");
		}

		if(line.StartsWith(">>"))
		{
			var command = line.Replace(">> ", "").Split(' ');

			ExecuteCommand(command[0], command[1..]);
		}
		else
		{
			this.AppendText(" " + Tr(line));
			canType = true;
		}
	}

	private void ExecuteCommand(string cmd, string[] args)
	{
		commands[cmd].Invoke(args);
	}
}
