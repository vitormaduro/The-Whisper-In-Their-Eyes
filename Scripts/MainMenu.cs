using Godot;

public partial class MainMenu : Control
{
	public void NewGame()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_screen.tscn");
	}

	public void OpenSettings()
	{
		GetTree().ChangeSceneToFile("res://Scenes/settings_menu.tscn");
	}

	public void QuitGame()
	{
		GetTree().Quit();
	}
}
