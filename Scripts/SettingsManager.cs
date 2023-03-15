using System;
using Godot;
using Godot.Collections;

public partial class SettingsManager : Node
{
	private const string LOCALE = "Locale";
	private const string TEXT_SPEED = "TextSpeed";
	private const string MUSIC_VOLUME = "MusicVolume";
	private const string SFX_VOLUME = "SfxVolume";
	private const string DISPLAY_MODE = "DisplayMode";
	private const string GALLERY_UNLOCKED = "GalleryUnlocked";

	public static string Locale { get; set; } = null;
	public static double TextSpeed { get; set; } = 100;
	public static double MusicVolume { get; set; } = 100;
	public static double SfxVolume { get; set; } = 100;
	public static Window.ModeEnum DisplayMode { get; set; } = Window.ModeEnum.Fullscreen;
	public static bool IsGamePaused { get; set; } = false;
	public static bool IsGalleryUnlocked { get; set; } = false;

	public override void _Ready()
	{
		var saveFile = FileAccess.Open("user://settings.save", FileAccess.ModeFlags.Read);

		// Creates a new Settings save file if none are present
		if(saveFile == null)
		{
			SaveSettings();
		}

		LoadSettings();

		TranslationServer.SetLocale(SettingsManager.Locale ?? "en");

		var root = GetTree().Root;

		if(DisplayMode == Window.ModeEnum.Windowed)
		{
			root.Borderless = false;
		}

		root.Mode = DisplayMode;
		root.Title = Tr("GAME_TITLE");

		base._Ready();
	}

	/// <summary>
    /// 	Saves all the settings in the game in a file called 'settings.save'. All values are converted to string before saving
    /// </summary>
	public static void SaveSettings()
	{
		using (var saveGame = FileAccess.Open("user://settings.save", FileAccess.ModeFlags.Write))
		{
			var saveData = new Dictionary<string, string>()
			{
				{ LOCALE, Locale },
				{ TEXT_SPEED, TextSpeed.ToString() },
				{ MUSIC_VOLUME, MusicVolume.ToString() },
				{ SFX_VOLUME, SfxVolume.ToString() },
				{ DISPLAY_MODE, DisplayMode.ToString() },
			};

			var json = Json.Stringify(saveData);

			saveGame.StoreLine(json);
		}
	}

	/// <summary>
    /// 	Loads all settings retrieved from the 'settings.save' file. All values are converted from string back to their original types
    /// </summary>
	public static void LoadSettings()
	{
		using(var saveGame = FileAccess.Open("user://settings.save", FileAccess.ModeFlags.Read))
		{
			while (saveGame.GetPosition() < saveGame.GetLength())
			{
				var jsonString = saveGame.GetLine();
				var json = new Json();
				var parseResult = json.Parse(jsonString);

				var nodeData = new Dictionary<string, string>((Dictionary) json.Data);

				Locale = nodeData[LOCALE];
				TextSpeed = double.Parse(nodeData[TEXT_SPEED]);
				MusicVolume = double.Parse(nodeData[MUSIC_VOLUME]);
				SfxVolume = double.Parse(nodeData[SFX_VOLUME]);

				if(Enum.TryParse(nodeData[DISPLAY_MODE], out Window.ModeEnum displayMode))
				{
					DisplayMode = displayMode;
				}
			}
		}
	}
}
