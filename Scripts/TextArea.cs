using System.Linq;
using Godot;

public partial class TextArea : RichTextLabel
{
	private bool canType = true;
	private bool isSkipping = false;
	private double timer = 0;
	private bool isWaiting = false;

	private InkHandler inkManager;
	private RichTextLabel history;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		inkManager = GetNode<InkHandler>("%InkScriptManager");
		history = GetNode<RichTextLabel>("../History");

		GetNode<TextureButton>("../../../QuickButtons/SkipButton").Pressed += () => isSkipping = !isSkipping;
		GetNode<TextureButton>("../../../QuickButtons/PauseButton").Pressed += () => SettingsManager.IsGamePaused = !SettingsManager.IsGamePaused;

		cmdManager.TextCleared += ClearText;
		cmdManager.ScreenCleared += ClearText;
		cmdManager.DisclaimerDisplayed += (string line) => PrintLine(Tr(line), true);
		cmdManager.StaticTriggered += (string mode) => ClearText();

		inkManager.StoryLoaded += GetNewLine;

		GuiInput += (InputEvent @event) => ProcessInput(@event);
	}

	private void ClearText()
	{
		Clear();

		history.AppendText("\n\n");

		VisibleCharacters = 0;
	}

	private void PrintLine(string line, bool printAtOnce = false)
	{
		AppendText(" " + line);

		history.AppendText(" " + line);

		canType = true;

		if(printAtOnce)
		{
			VisibleCharacters = -1;
		}
	}

	public override void _Process(double delta)
	{
		if(SettingsManager.IsGamePaused)
		{
			return;
		}

		timer += delta;

		if(isSkipping || (canType && timer >= (1f / SettingsManager.TextSpeed) && VisibleCharacters >= 0))
		{
			timer = 0f;

			VisibleCharacters++;

			if(VisibleRatio == 1)
			{
				canType = false;
			}
		}

		if(isSkipping)
		{
			if(canType)
			{
				VisibleCharacters = GetTotalCharacterCount();
				canType = false;
			}
			else
			{
				GetNewLine();
			}
		}
	}

	private async void GetNewLine()
	{
		if(isWaiting)
		{
			return;
		}

		isWaiting = true;

		var inkLine = await inkManager.ContinueStory();

		var line = ProcessTags(inkLine);

		PrintLine(line);

		isWaiting = false;
	}

	private void ProcessInput(InputEvent @event)
	{
		if(SettingsManager.IsGamePaused)
		{
			return;
		}

		if(@event.IsActionPressed("text_advance"))
		{
			if(canType)
			{
				VisibleCharacters = GetTotalCharacterCount();
				canType = false;
			}
			else
			{
				GetNewLine();
			}
		}
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("skip_text"))
		{
			isSkipping = true;
		}
		else if(@event.IsActionReleased("skip_text"))
		{
			isSkipping = false;
		}
	}

	private string ProcessTags(InkLine inkLine)
	{
		if(inkLine == null)
		{
			return null;
		}

		var temp = inkLine.Line;

		if(inkLine.Tags.Contains("title"))
		{
			var blocks = temp.Split(": ");

			temp = $"[font_size=120][center]\n{blocks[0]}: \n{blocks[1]}[/center][/font_size]";
		}

		if(inkLine.Tags.Contains("black"))
		{
			temp = $"[outline_size=5][color=black]{temp}[/color][/outline_size]";
		}

		if(inkLine.Tags.Contains("shake"))
		{
			temp = $"[shake rate=5 level=10]{temp}[/shake]";
		}

		return temp;
	}
}
