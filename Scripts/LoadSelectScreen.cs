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
	}
	
	public void SetScreenMode(SceneMode mode)
	{
		for (var i = 1; i <= 3; i++)
		{
			var saveData = SaveManager.GetSaveFileData($"slot_{i}");
			var button = GetNode<Button>($"%SaveLoadButton{i}");
			var temp = i;

			if(saveData == null)
			{
				button.GetNode<Label>("Label").Text = Tr("NO_DATA");

				if(mode == SceneMode.Load)
				{
					button.Disabled = true;
				}
			}
			else 
			{
				var dateTemplate = SettingsManager.Locale == "en" ? "MMMM dd, HH:mm" : "dd 'de' MMMM, HH:mm";

				DateTime.TryParseExact(saveData["Date"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

				button.GetNode<Label>("Label").Text = $"{Tr("SAVE_DATA")} 0{i}\n{date.ToString(dateTemplate)}";
				button.GetNode<TextureRect>("TextureRect").Texture = GD.Load<Texture2D>($"res://Art/Backgrounds/{saveData["CurrentBg"]}.jpg");
			}

			if(mode == SceneMode.Load)
			{
				button.Pressed += () =>
				{
					SaveManager.LoadSaveSlot(temp);
					SettingsManager.IsGamePaused = false;

					EmitSignal(SignalName.GameLoaded);
					QueueFree();
				};
			}
			else 
			{
				button.Pressed += () =>
				{
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
