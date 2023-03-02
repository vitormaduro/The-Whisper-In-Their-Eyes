using Godot;

public partial class Credits : Control
{
	public override void _Ready()
	{
		GetNode<Button>("BackButton").Pressed += BackToMainMenu;

		base._Ready();
	}

	public void BackToMainMenu()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
	}
}
