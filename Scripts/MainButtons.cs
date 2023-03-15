using Godot;
using static Enums;

public partial class MainButtons : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("%QuickSaveButton").Pressed += () => SaveManager.SaveGameAt("quick");
		GetNode<TextureButton>("%QuickLoadButton").Pressed += SaveManager.LoadQuickSave;
		GetNode<TextureButton>("%ManualSaveButton").Pressed += () => OpenSaveLoadScene(SceneMode.Save);
		GetNode<TextureButton>("%ManualLoadButton").Pressed += () => OpenSaveLoadScene(SceneMode.Load);

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

	private void OpenSaveLoadScene(SceneMode mode)
	{
		SettingsManager.IsGamePaused = true;

		var saveLoadScreen = GD.Load<PackedScene>($"res://Scenes/load_selection.scn");

		GetNode<CanvasLayer>("/root/CanvasLayer").AddChild(saveLoadScreen.Instantiate());

		var instance = GetNode<LoadSelectScreen>("/root/CanvasLayer/SaveLoadScreen");

		instance.SetScreenMode(mode);
		instance.GameLoaded += () =>
		{
			GetNode<InkHandler>("%TextArea").JumpToScene(SaveManager.CurrentScene);
		};
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("save"))
		{
			OpenSaveLoadScene(SceneMode.Save);
		}
		else if(@event.IsActionPressed("load"))
		{
			OpenSaveLoadScene(SceneMode.Load);
		}
		else if(@event.IsActionPressed("quick_save"))
		{
			SaveManager.SaveGameAt("quick");
		}
	}
}
