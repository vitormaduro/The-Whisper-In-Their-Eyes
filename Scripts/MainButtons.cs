using Godot;
using static Enums;

public partial class MainButtons : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("%QuickSaveButton").Pressed += () => SaveManager.SaveGameAt("quick");
		GetNode<TextureButton>("%QuickLoadButton").Pressed += () => LoadQuickSave();
		GetNode<TextureButton>("%ManualSaveButton").Pressed += () => OpenSaveLoadScene(SceneMode.Save);
		GetNode<TextureButton>("%ManualLoadButton").Pressed += () => OpenSaveLoadScene(SceneMode.LoadDuringGame);

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

	private void LoadQuickSave()
	{
		SaveManager.LoadQuickSave();
		SettingsManager.IsGamePaused = false;
		GetTree().ChangeSceneToFile("res://Scenes/main_screen.scn");
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
			GetNode<TextArea>("%TextArea").Clear();
			GetNode<InkHandler>("%InkScriptManager").JumpToScene(SaveManager.CurrentScene, SaveManager.CurrentStitch);
			GetNode<BackgroundManager>("%BackgroundImage").ChangeBackground(SaveManager.CurrentBg);
		};
	}

	public override void _Input(InputEvent @event)
	{
		if(SettingsManager.IsConsoleOpen)
		{
			return;
		}
		
		if(@event.IsActionPressed("save"))
		{
			OpenSaveLoadScene(SceneMode.Save);
		}
		else if(@event.IsActionPressed("load"))
		{
			OpenSaveLoadScene(SceneMode.LoadDuringGame);
		}
		else if(@event.IsActionPressed("quick_save"))
		{
			SaveManager.SaveGameAt("quick");
		}
	}
}
