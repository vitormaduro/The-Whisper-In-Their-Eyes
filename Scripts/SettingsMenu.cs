using Godot;

public partial class SettingsMenu : Control
{
	private Label textSpeedLabel;
	private Label volumeLabel;

	/// <summary>
    /// 	Adds an Event Listener to every component in the Settings screen, triggering methods when they are changed
    /// </summary>
	public override void _Ready()
	{
		textSpeedLabel = GetNode<Label>("%TextSpeedValue");
		volumeLabel = GetNode<Label>("%VolumeValue");

		GetNode<OptionButton>("%DisplayModeSelect").ItemSelected += (index) => UpdateDisplayMode(index);

		GetNode<OptionButton>("%LanguageSelect").ItemSelected += (index) => UpdateLanguage(index);

		GetNode<Slider>("%TextSpeedSlider").ValueChanged += (value) => UpdateTextSpeed(value);
		GetNode<Slider>("%TextSpeedSlider").DragEnded += (value) => SettingsManager.SaveSettings();
		GetNode<Slider>("%TextSpeedSlider").Value = SettingsManager.TextSpeed;

		GetNode<Slider>("%VolumeSlider").ValueChanged += (value) => UpdateVolume(value);
		GetNode<Slider>("%VolumeSlider").DragEnded += (value) => SettingsManager.SaveSettings();
		GetNode<Slider>("%VolumeSlider").Value = SettingsManager.Volume;

		GetNode<Button>("%BackButton").Pressed += BackToMainMenu;

		GetNode<OptionButton>("%DisplayModeSelect").Selected = SettingsManager.DisplayMode == Window.ModeEnum.Fullscreen ? 0 : 1;
		GetNode<OptionButton>("%LanguageSelect").Selected = SettingsManager.Locale == "pt_BR" ? 1 : 0;

		base._Ready();
	}

	/// <summary>
    /// 	Updates the language of the game
    /// </summary>
    /// <param name="languageId">ID of the desired language (0: English; 1: PT-BR)</param>
	public void UpdateLanguage(long languageId)
	{
		var locale = languageId == 0 ? "en" : "pt_BR";

		SettingsManager.Locale = locale;

		TranslationServer.SetLocale(locale);
		SettingsManager.SaveSettings();

		textSpeedLabel.Text = $"{SettingsManager.TextSpeed} {Tr("CHARACTERS_PER_SECOND")}";
		GetTree().Root.Title = Tr("GAME_TITLE");
	}

	/// <summary>
    /// 	Updates the speed in which characters are shown during the story
    /// </summary>
    /// <param name="speed">The new speed, in characters per second</param>
	public void UpdateTextSpeed(double speed)
	{
		SettingsManager.TextSpeed = speed;

		textSpeedLabel.Text = $"{speed} {Tr("CHARACTERS_PER_SECOND")}";
	}

	/// <summary>
    /// 	Updates the volume of the sound effects
    /// </summary>
    /// <param name="volume">The new volume, ranging from 0 (no sound) to 100 (regular volume)</param>
	public void UpdateVolume(double volume)
	{
		SettingsManager.Volume = volume;

		volumeLabel.Text = $"{volume}";
	}

	public void UpdateDisplayMode(long displayModeId)
	{
		var mode = displayModeId switch {
			0 => Window.ModeEnum.Fullscreen,
			_ => Window.ModeEnum.Windowed
		};

		UpdateDisplayMode(mode);

		SettingsManager.SaveSettings();
	}

	private void UpdateDisplayMode(Window.ModeEnum mode)
	{
		var root = GetTree().Root;

		if(mode == Window.ModeEnum.Windowed)
		{
			root.Borderless = false;
		}

		root.Mode = mode;

		SettingsManager.DisplayMode = mode;
	}

	public void BackToMainMenu()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
	}
}
