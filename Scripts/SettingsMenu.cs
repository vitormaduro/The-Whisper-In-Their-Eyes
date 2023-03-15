using Godot;
using static Enums;

public partial class SettingsMenu : Control
{
	private Label textSpeedLabel;
	private Label musicVolumeLabel;
	private Label sfxVolumeLabel;

	/// <summary>
    /// 	Adds an Event Listener to every component in the Settings screen, triggering methods when they are changed
    /// </summary>
	public override void _Ready()
	{
		textSpeedLabel = GetNode<Label>("%TextSpeedValue");
		musicVolumeLabel = GetNode<Label>("%MusicVolumeValue");
		sfxVolumeLabel = GetNode<Label>("%SfxVolumeValue");

		GetNode<TextureButton>("%DisplayModeWindowed").Pressed += () => UpdateDisplayMode(Window.ModeEnum.Windowed);
		GetNode<TextureButton>("%DisplayModeFullscreen").Pressed += () => UpdateDisplayMode(Window.ModeEnum.Fullscreen);

		GetNode<TextureButton>("%LanguageEnglish").Pressed += () => UpdateLanguage(Language.English);
		GetNode<TextureButton>("%LanguagePortuguese").Pressed += () => UpdateLanguage(Language.Portuguese);

		GetNode<Slider>("%TextSpeedSlider").ValueChanged += (value) => UpdateTextSpeed(value);
		GetNode<Slider>("%TextSpeedSlider").DragEnded += (value) => SettingsManager.SaveSettings();
		GetNode<Slider>("%TextSpeedSlider").Value = SettingsManager.TextSpeed;

		GetNode<Slider>("%MusicVolumeSlider").ValueChanged += (value) => UpdateMusicVolume(value);
		GetNode<Slider>("%MusicVolumeSlider").DragEnded += (value) => SettingsManager.SaveSettings();
		GetNode<Slider>("%MusicVolumeSlider").Value = SettingsManager.MusicVolume;

		GetNode<Slider>("%SfxVolumeSlider").ValueChanged += (value) => UpdateSfxVolume(value);
		GetNode<Slider>("%SfxVolumeSlider").DragEnded += (value) => SettingsManager.SaveSettings();
		GetNode<Slider>("%SfxVolumeSlider").Value = SettingsManager.SfxVolume;

		GetNode<TextureButton>("%BackButton").Pressed += CloseScreen;

		GetNode<ToggleButton>("%DisplayModeFullscreen").SetSelected(SettingsManager.DisplayMode == Window.ModeEnum.Fullscreen);
		GetNode<ToggleButton>("%DisplayModeWindowed").SetSelected(SettingsManager.DisplayMode == Window.ModeEnum.Windowed);

		GetNode<ToggleButton>("%LanguageEnglish").SetSelected(SettingsManager.Locale == "en");
		GetNode<ToggleButton>("%LanguagePortuguese").SetSelected(SettingsManager.Locale == "pt_BR");

		textSpeedLabel.Text = $"{SettingsManager.TextSpeed} {Tr("CHARACTERS_PER_SECOND")}";
	}

	/// <summary>
    /// 	Updates the language of the game
    /// </summary>
    /// <param name="languageId">ID of the desired language (0: English; 1: PT-BR)</param>
	public void UpdateLanguage(Language language)
	{
		var locale = language == Language.English ? "en" : "pt_BR";

		SettingsManager.Locale = locale;

		GetNode<ToggleButton>("%LanguageEnglish").SetSelected(language == Language.English);
		GetNode<ToggleButton>("%LanguagePortuguese").SetSelected(language == Language.Portuguese);

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
	public void UpdateMusicVolume(double volume)
	{
		SettingsManager.MusicVolume = volume;

		musicVolumeLabel.Text = $"{volume}";
	}

	public void UpdateSfxVolume(double volume)
	{
		SettingsManager.SfxVolume = volume;

		sfxVolumeLabel.Text = $"{volume}";
	}

	private void UpdateDisplayMode(Window.ModeEnum mode)
	{
		var root = GetTree().Root;

		root.Borderless = mode != Window.ModeEnum.Windowed;

		GetNode<ToggleButton>("%DisplayModeFullscreen").SetSelected(mode == Window.ModeEnum.Fullscreen);
		GetNode<ToggleButton>("%DisplayModeWindowed").SetSelected(mode == Window.ModeEnum.Windowed);

		root.Mode = mode;

		SettingsManager.DisplayMode = mode;

		SettingsManager.SaveSettings();
	}

	public void CloseScreen()
	{
		QueueFree();
	}
}
