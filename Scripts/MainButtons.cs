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
			GetTree().ChangeSceneToFile("res://Scenes/main_screen.scn");
		};

		GetNode<TextureButton>("%SettingsButton").Pressed += () =>
		{
			var settings = GD.Load<PackedScene>($"res://Scenes/settings_menu.scn");

			GetNode<CanvasLayer>("/root/CanvasLayer").AddChild(settings.Instantiate());
		};

		GetNode<TextureButton>("%QuitButton").Pressed += () =>
		{
			var popup = GD.Load<PackedScene>($"res://Scenes/confirm_popup.scn");

			GetNode<CanvasLayer>("/root/CanvasLayer").AddChild(popup.Instantiate());
			GetNode<ConfirmPopup>("/root/CanvasLayer/ConfirmPopup").SetYesButtonAction(() => GetTree().ChangeSceneToFile("res://Scenes/main_menu.scn"));
		};
	}

	private void UpdateSlotButtonLabel()
	{
		var manualSaveButton = GetNode<MenuButton>("%ManualSaveButton");
		var manualLoadButton = GetNode<MenuButton>("%ManualLoadButton");

		for (var i = 0; i < 3; i++)
		{
			var temp = i + 1;
			var saveFile = SaveManager.GetSaveFileData($"slot_{temp}");
			var savePopup = manualSaveButton.GetPopup();
			var loadPopup = manualLoadButton.GetPopup();

			if(saveFile != null)
			{
				DateTime.TryParseExact(saveFile["Date"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var saveDate);

				savePopup.SetItemText(i, $"{temp} - {saveDate.ToString("yyyy-MM-dd HH:mm:ss")}");
				loadPopup.SetItemText(i, $"{temp} - {saveDate.ToString("yyyy-MM-dd HH:mm:ss")}");
				loadPopup.SetItemDisabled(i, false);
			}
			else
			{
				savePopup.SetItemText(i, $"{temp} - {Tr("NO_DATA")}");
				loadPopup.SetItemText(i, $"{temp} - {Tr("NO_DATA")}");
				loadPopup.SetItemDisabled(i, true);
			}
		}
	}
}
