using Godot;

public partial class TextArea : RichTextLabel
{
	private bool canType = true;
	private bool isSkipping = true;
	private double timer = 0;
	private InkHandler inkManager;
	private bool isWaiting = false;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		inkManager = GetNode<InkHandler>("%InkScriptManager");

		cmdManager.TextCleared += ClearText;
		cmdManager.ScreenCleared += ClearText;
		cmdManager.DisclaimerDisplayed += (string line) => PrintLine(Tr(line));
	}

	private void ClearText()
	{
		Clear();
		VisibleCharacters = 0;
	}

	private void PrintLine(string line)
	{
		AppendText(" " + line);

		canType = true;
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

			VisibleCharacters++;

			if(VisibleRatio == 1)
			{
				canType = false;
			}
		}

		if(isSkipping || Input.IsActionJustPressed("text_advance"))
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

		PrintLine(await inkManager.ContinueStory());

		isWaiting = false;
	}
}
