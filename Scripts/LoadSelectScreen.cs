using System;
using System.Globalization;
using Godot;
using static Enums;

public partial class LoadSelectScreen : Control
{
	[Signal]
	public delegate void GameLoadedEventHandler();

	public override void _Ready()
	{
		GetNode<TextureButton>("%BackButton").Pressed += CloseScreen;

		GD.Print("Save/Load scene loaded with default values");
	}
	
	public void SetScreenMode(SceneMode mode)
	{
		GD.Print($"Settings Save/Load scene to mode [{mode.ToString()}]");

		for (var i = 1; i <= 3; i++)
		{
			GD.Print($"Looking for file [slot_{i}.save]...");

			var saveData = SaveManager.GetSaveFileData($"slot_{i}");
			var button = GetNode<Button>($"%SaveLoadButton{i}");
			var temp = i;

			if(saveData == null)
			{
				GD.PushWarning($"File [slot_{i}.save] not found");

				button.GetNode<Label>("Label").Text = Tr("NO_DATA");

				if(mode is SceneMode.LoadDuringGame or SceneMode.LoadMainMenu)
				{
					button.Disabled = true;
				}
			}
			else 
			{
				GD.Print($"File [slot_{i}.save] loaded successfully");

				var dateTemplate = SettingsManager.Locale == "en" ? "MMMM dd, HH:mm" : "dd 'de' MMMM, HH:mm";

				DateTime.TryParseExact(saveData["Date"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

				button.GetNode<Label>("Label").Text = $"{Tr("SAVE_DATA")} 0{i}\n{date.ToString(dateTemplate)}";
				button.GetNode<TextureRect>("TextureRect").Texture = GD.Load<Texture2D>($"res://Art/Backgrounds/{saveData["CurrentBg"]}.jpg");
			}

			if(mode is SceneMode.LoadDuringGame or SceneMode.LoadMainMenu)
			{
				button.Pressed += () =>
				{
					GD.Print($"Loading data from file [slot_{temp}.save]");

					SaveManager.LoadSaveSlot(temp);
					SettingsManager.IsGamePaused = false;

					EmitSignal(SignalName.GameLoaded);

					if(mode is SceneMode.LoadMainMenu)
					{
						GetTree().ChangeSceneToFile("res://Scenes/main_screen.scn");
					}
					else 
					{
						QueueFree();
					}
				};
			}
			else 
			{
				button.Pressed += () =>
				{
					GD.Print($"Saving data to file [slot_{temp}.save]");

					SaveManager.SaveGameAt($"slot_{temp}");
					SettingsManager.IsGamePaused = false;

					QueueFree();
				};
			}
		}

		if(mode == SceneMode.Save)
		{
			GetNode<Label>("Name").Text = Tr("SAVE");
		}
		else 
		{
			GetNode<Label>("Name").Text = Tr("LOAD");
		}
	}

	public void CloseScreen()
	{
		SettingsManager.IsGamePaused = false;

		QueueFree();
	}
}
