using System;
using System.Globalization;
using Godot;

public partial class MainButtons : Control
{
	public override void _Ready()
	{
		UpdateSlotButtonLabel();

		GetNode<MenuButton>("%ManualSaveButton").GetPopup().IdPressed += (id) =>
		{
			SaveManager.SaveGameAt($"slot_{id}");
			UpdateSlotButtonLabel();
		};

		GetNode<MenuButton>("%ManualLoadButton").GetPopup().IdPressed += (id) =>
		{
			SaveManager.LoadSaveSlot((int) id);
			GetTree().ChangeSceneToFile("res://Scenes/main_screen.tscn");
		};

		GetNode<Button>("%QuitButton").Pressed += () =>
		{
			GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
		};
	}

	private void UpdateSlotButtonLabel()
	{
		var manualSaveButton = GetNode<MenuButton>("%ManualSaveButton");
		var manualLoadButton = GetNode<MenuButton>("%ManualLoadButton");

		for (var i = 1; i <= 3; i++)
		{
			var temp = i;
			var saveFile = SaveManager.GetSaveFileData($"slot_{temp}");
			var savePopup = manualSaveButton.GetPopup();
			var loadPopup = manualLoadButton.GetPopup();

			if(saveFile != null)
			{
				DateTime.TryParseExact(saveFile["Date"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var saveDate);

				savePopup.SetItemText(temp, $"{temp} - {saveDate.ToString("yyyy-MM-dd HH:mm:ss")}");
				loadPopup.SetItemText(temp, $"{temp} - {saveDate.ToString("yyyy-MM-dd HH:mm:ss")}");
				loadPopup.SetItemDisabled(temp, false);
			}
			else
			{
				savePopup.SetItemText(temp, $"{temp} - {Tr("NO_DATA")}");
				loadPopup.SetItemText(temp, $"{temp} - {Tr("NO_DATA")}");
				loadPopup.SetItemDisabled(temp, true);
			}
		}
	}
}
