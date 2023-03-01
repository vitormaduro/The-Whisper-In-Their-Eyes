using Godot;
using Godot.Collections;

public partial class SaveManager : Node
{
	public static string CurrentTag { get; set; } = null;
	public static string Locale { get; set; } = null;

	public override void _Ready()
	{
		LoadSettings();

		TranslationServer.SetLocale(Locale ?? "en");

		base._Ready();
	}

	public static void QuickSave()
	{
		using (var saveGame = FileAccess.Open("user://quick.save", FileAccess.ModeFlags.Write))
		{
			var saveData = new Dictionary<string, string>()
			{
				{ "CurrentTag", CurrentTag },
				{ "Locale", Locale }
			};

			var json = Json.Stringify(saveData);

			saveGame.StoreLine(json);
		}
	}

	public void LoadGame()
	{
		using(var saveGame = FileAccess.Open("user://quick.save", FileAccess.ModeFlags.Read))
		{
			while (saveGame.GetPosition() < saveGame.GetLength())
			{
				var jsonString = saveGame.GetLine();
				var json = new Json();
				var parseResult = json.Parse(jsonString);

				if (parseResult != Error.Ok)
				{
					GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
					continue;
				}

				// Get the data from the JSON object
				var nodeData = new Dictionary<string, string>((Dictionary) json.Data);

				SaveManager.CurrentTag = nodeData["CurrentTag"];

				GetTree().ChangeSceneToFile("res://Scenes/main_screen.tscn");
			}
		}
	}

	public static void SaveSettings()
	{
		using (var saveGame = FileAccess.Open("user://settings.save", FileAccess.ModeFlags.Write))
		{
			var saveData = new Dictionary<string, string>()
			{
				{ "Locale", Locale }
			};

			var json = Json.Stringify(saveData);

			saveGame.StoreLine(json);
		}
	}

	public static void LoadSettings()
	{
		using(var saveGame = FileAccess.Open("user://settings.save", FileAccess.ModeFlags.Read))
		{
			while (saveGame.GetPosition() < saveGame.GetLength())
			{
				var jsonString = saveGame.GetLine();
				var json = new Json();
				var parseResult = json.Parse(jsonString);

				if (parseResult != Error.Ok)
				{
					GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
					continue;
				}

				// Get the data from the JSON object
				var nodeData = new Dictionary<string, string>((Dictionary) json.Data);

				SaveManager.Locale = nodeData["Locale"];
			}
		}
	}
}
