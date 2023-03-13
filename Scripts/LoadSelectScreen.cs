using System;
using System.Globalization;
using Godot;

public partial class LoadSelectScreen : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("%BackButton").Pressed += BackToMainMenu;

		for (var i = 1; i <= 3; i++)
		{
			var saveData = SaveManager.GetSaveFileData($"slot_{i}");
			var loadButton = GetNode<Button>($"%LoadButton{i}");

			if(saveData == null)
			{
				loadButton.Disabled = true;
				loadButton.GetNode<Label>("Label").Text = Tr("NO_DATA");
			}
			else 
			{
				var temp = i;
				var dateTemplate = SettingsManager.Locale == "en" ? "MMMM dd, HH:mm" : "dd 'de' MMMM, HH:mm";

				DateTime.TryParseExact(saveData["Date"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);
				loadButton.GetNode<Label>("Label").Text = $"{Tr("SAVE_DATA")} 0{i}\n{date.ToString(dateTemplate)}";

				loadButton.Pressed += () =>
				{
					SaveManager.LoadSaveSlot(temp);
					GetTree().ChangeSceneToFile("res://Scenes/main_screen.tscn");
				};
			}
		}

		base._Ready();
	}
	
	public void BackToMainMenu()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
	}
}
