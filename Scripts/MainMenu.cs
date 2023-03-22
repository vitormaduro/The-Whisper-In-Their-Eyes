using Godot;
using static Enums;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GetNode<Button>("%NewGameButton").Pressed += StartNewGame;
		GetNode<Button>("%LoadGameButton").Pressed += () =>
		{
			OpenScene("load_selection");
			GetNode<LoadSelectScreen>("../SaveLoadScreen").SetScreenMode(SceneMode.Load);
		};
		GetNode<Button>("%SettingsButton").Pressed += () => OpenScene("settings_menu");
		GetNode<Button>("%CreditsButton").Pressed += () => OpenScene("credits");
		GetNode<Button>("%QuitButton").Pressed += () =>
		{
			OpenScene("confirm_popup");
			GetNode<ConfirmPopup>("../ConfirmPopup").SetYesButtonAction(() => GetTree().Quit());
		};

		var galleryButton = GetNode<Button>("%GalleryButton");

		galleryButton.Visible = SettingsManager.IsGalleryUnlocked;
		galleryButton.Pressed += () => OpenScene("gallery");

		GD.Print("Main Menu loaded successfully");
	}

	private void StartNewGame()
	{
		GD.Print("Starting new game");

		GetNode<AnimationPlayer>("%AnimationPlayer").Play("new_game");
		GetTree().CreateTimer(2).Timeout += () =>
		{
			SaveManager.CurrentScene = null;

			GetTree().ChangeSceneToFile($"res://Scenes/main_screen.scn");
		};
	}

	private void OpenScene(string sceneName)
	{
		GD.Print($"Opening scene {sceneName}");

		var scene = GD.Load<PackedScene>($"res://Scenes/{sceneName}.scn");

		GetTree().Root.AddChild(scene.Instantiate());
	}
}
