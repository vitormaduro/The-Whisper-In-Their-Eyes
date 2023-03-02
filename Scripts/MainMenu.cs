using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GetNode<Button>("%NewGameButton").Pressed += () => LoadScene("main_screen");
		GetNode<Button>("%LoadGameButton").Pressed += () => LoadScene("load_selection");
		GetNode<Button>("%SettingsButton").Pressed += () => LoadScene("settings_menu");
		GetNode<Button>("%CreditsButton").Pressed += () => LoadScene("credits");
		GetNode<Button>("%QuitButton").Pressed += () => GetTree().Quit();

		base._Ready();
	}

	private void LoadScene(string scene)
	{
		GetTree().ChangeSceneToFile($"res://Scenes/{scene}.tscn");
	}
}
