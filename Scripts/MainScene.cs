using Godot;

public partial class MainScene : Control
{
	private Control nvlBox;
	private InkCommandsManager cmdManager;
	private RichTextLabel history;
	private TextureRect bgImage;

	public override void _Ready()
	{
		nvlBox = GetNode<Control>("NVLBox");
		cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");
		history = GetNode<RichTextLabel>("%History");
		bgImage = GetNode<TextureRect>("%BackgroundImage");

		GetNode<TextureButton>("%PageMarker").Pressed += PauseGame;
		GetNode<Button>("%UnpauseButton").Pressed += ResumeGame;
		GetNode<TextureButton>("QuickButtons/LogButton").Pressed += ToggleHistory;
		GetNode<TextureButton>("QuickButtons/NvlBoxButton").Pressed += ToggleText;

		GetNode<Control>("%PauseMenu").Visible = false;
		GetNode<TextureRect>("%Static").Visible = false;

		history.Visible = false;

		cmdManager.CgTriggered += (string cgName) => StartCg(cgName);
		cmdManager.NvlBoxWasHidden += () => HideNvlBox(true);
		cmdManager.SlowZoomWasTriggered += (string pivotX, string pivotY, string scale) => HideNvlBox(false);
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("toggle_nvl_box"))
		{
			ToggleText();
		}
		else if(@event.IsActionPressed("toggle_history"))
		{
			ToggleHistory();
		}
	}

	public void PauseGame()
	{
		SettingsManager.IsGamePaused = true;

		GetNode<Control>("%PauseMenu").Visible = true;
		GetNode<AnimationPlayer>("%AnimationPlayer").SpeedScale = 0;
	}

	public void ResumeGame()
	{
		SettingsManager.IsGamePaused = false;

		GetNode<Control>("%PauseMenu").Visible = false;

		GetNode<AnimationPlayer>("%AnimationPlayer").SpeedScale = 1;
	}

	private void ToggleHistory()
	{
		history.Visible = !history.Visible;
		GetNode<RichTextLabel>("%TextArea").Visible = !history.Visible;
		SettingsManager.IsGamePaused = history.Visible;
	}

	private void ToggleText()
	{
		nvlBox.Visible = !nvlBox.Visible;
	}

	private void StartCg(string cgName)
	{
		SettingsManager.IsGamePaused = true;

		nvlBox.Visible = false;
		history.Visible = false;
		bgImage.Texture = GD.Load<Texture2D>($"res://Art/CGs/{cgName}.png");

		GetTree().CreateTimer(10).Timeout += () =>
		{
			nvlBox.Visible = true;
			SettingsManager.IsGamePaused = false;
		};
	}

	private void HideNvlBox(bool autoRestore)
	{
		nvlBox.Visible = false;

		if(autoRestore)
		{
			GetTree().CreateTimer(5).Timeout += () =>
			{
				nvlBox.Visible = true;
			};
		}
	}
}
