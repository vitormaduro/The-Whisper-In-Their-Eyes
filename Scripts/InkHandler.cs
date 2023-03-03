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
	private Dictionary<string, Action<string[]>> commands;

	public override void _Ready()
	{
		if(SaveManager.CurrentTag != null)
		{
			JumpToKnot(SaveManager.CurrentTag);
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
					GetNode<TextureRect>("%BackgroundImage").Texture = (Texture2D) GD.Load($"{res}/Backgrounds/{args[0]}.jpg");
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
			}
		};
	}

	public override void _Process(double delta)
	{
		timer += delta;

		if(canType && timer >= (1f / SettingsManager.TextSpeed))
		{
			timer = 0f;

			this.VisibleCharacters++;

			if(this.VisibleRatio == 1)
			{
				canType = false;
			}
		}

		if(Input.IsActionJustPressed("text_advance"))
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

	public void JumpToKnot(string knotName)
	{
		story.ChoosePathString(knotName);
	}

	private void ContinueStory()
	{
		if(!story.CanContinue)
		{
			return;
		}

		var line = story.Continue();
		var tags = story.CurrentTags;

		if(tags.Any(t => t.StartsWith("KNOT")))
		{
			SaveManager.CurrentTag = tags.Where(t => t.StartsWith("KNOT")).First().Replace("KNOT:", "");
		}

		if(line.StartsWith(">>"))
		{
			var command = line.Replace(">> ", "").Replace("\n", "").Split(' ');

			ExecuteCommand(command[0], command[1..]);
		}
		else
		{
			this.Text += Tr(line);
			canType = true;
		}
	}

	private void ExecuteCommand(string command, string[] args)
	{
		commands[command].Invoke(args);
	}
}
