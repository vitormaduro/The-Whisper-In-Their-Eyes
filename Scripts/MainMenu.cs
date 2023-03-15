using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GetNode<Button>("%NewGameButton").Pressed += () => LoadScene("main_screen");
		GetNode<Button>("%LoadGameButton").Pressed += () => LoadScene("load_selection");
		GetNode<Button>("%SettingsButton").Pressed += () => OpenScene("settings_menu");
		GetNode<Button>("%CreditsButton").Pressed += () => LoadScene("credits");
		GetNode<Button>("%QuitButton").Pressed += () =>
		{
			OpenScene("confirm_popup");
			GetNode<ConfirmPopup>("../ConfirmPopup").SetYesButtonAction(() => GetTree().Quit());
		};

		base._Ready();
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
