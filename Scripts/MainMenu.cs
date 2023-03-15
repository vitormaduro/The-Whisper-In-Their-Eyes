using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GetNode<Button>("%NewGameButton").Pressed += StartNewGame;
		GetNode<Button>("%LoadGameButton").Pressed += () => OpenScene("load_selection");
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
	}

	private void StartNewGame()
	{
		SaveManager.CurrentScene = null;
		SaveManager.CurrentAct = "1";

		LoadScene("main_screen");
	}

	private void LoadScene(string scene)
	{
		GetTree().ChangeSceneToFile($"res://Scenes/{scene}.scn");
	}

	private void OpenScene(string sceneName)
	{
		var scene = GD.Load<PackedScene>($"res://Scenes/{sceneName}.scn");

		GetTree().Root.AddChild(scene.Instantiate());
	}
}
