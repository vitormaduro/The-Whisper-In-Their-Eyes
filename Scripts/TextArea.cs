using System.Linq;
using Godot;

public partial class TextArea : RichTextLabel
{
	private bool canType = true;
	private bool isSkipping = false;
	private double timer = 0;
	private bool isWaiting = false;
	private bool mustTab = true;

	private InkHandler inkManager;
	private RichTextLabel history;
	private TextureButton skipButton;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		inkManager = GetNode<InkHandler>("%InkScriptManager");
		history = GetNode<RichTextLabel>("../History");
		skipButton = GetNode<TextureButton>("../../../QuickButtons/SkipButton");

		skipButton.Pressed += ToggleSkip;
		
		GetNode<TextureButton>("../../../QuickButtons/PauseButton").Pressed += () => SettingsManager.IsGamePaused = !SettingsManager.IsGamePaused;

		cmdManager.TextCleared += ClearText;
		cmdManager.ScreenCleared += ClearText;
		cmdManager.DisclaimerDisplayed += (string line) => PrintLine(Tr(line), true);
		cmdManager.StaticTriggered += (string mode) => ClearText();

		inkManager.StoryLoaded += GetNewLine;

		GuiInput += (InputEvent @event) => ProcessInput(@event);
	}

	private void ToggleSkip()
	{
		isSkipping = !isSkipping;

		skipButton.TextureNormal = GD.Load<Texture2D>($"res://Art/UI/QuickButtons/{(isSkipping ? "skip_selected" : "skip")}.png");
		skipButton.TextureHover = GD.Load<Texture2D>($"res://Art/UI/QuickButtons/{(isSkipping ? "skip_selected_hover" : "skip_hover")}.png");
	}

	private void ClearText()
	{
		Clear();

		history.AppendText("\n\n");

		using (var hist = FileAccess.Open($"user://history.txt", FileAccess.ModeFlags.ReadWrite))
		{
			hist.SeekEnd();
			hist.StoreString("\n");
		}

		VisibleCharacters = 0;
		mustTab = true;
	}

	private void PrintLine(string line, bool printAtOnce = false)
	{
		AppendText((mustTab ? '\t' : ' ') + line);

		history.AppendText((mustTab ? '\t' : ' ') + line);

		canType = true;
		mustTab = false;

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

		if(@event.IsActionPressed("text_advance_mouse"))
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
		if(@event.IsActionPressed("text_advance_keyboard"))
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
		else if(@event.IsActionPressed("skip_text"))
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

		if(inkLine.Tags.Contains("big"))
		{
			temp = $"[font_size=120][center]{temp}[/center][/font_size]";
		}

		if(inkLine.Tags.Contains("black"))
		{
			temp = $"[outline_size=5][color=black]{temp}[/color][/outline_size]";
		}

		if(inkLine.Tags.Contains("blue"))
		{
			temp = $"[color=blue]{temp}[/color]";
		}

		if(inkLine.Tags.Contains("red"))
		{
			temp = $"[color=red]{temp}[/color]";
		}

		if(inkLine.Tags.Contains("shake"))
		{
			temp = $"[shake rate=5 level=10]{temp}[/shake]";
		}

		if(inkLine.Tags.Contains("center"))
		{
			temp = $"[center]{temp}[/center]";
		}

		if(inkLine.Tags.Contains("b"))
		{
			temp = $"[b]{temp}[/b]";
		}

		if(inkLine.Tags.Contains("i"))
		{
			temp = $"[i]{temp}[/i]";
		}

		if(inkLine.Tags.Contains("n"))
		{
			temp += "\n\n\t";
		}

		return temp;
	}
}
