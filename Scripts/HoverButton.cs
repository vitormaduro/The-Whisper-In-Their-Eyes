using Godot;

public partial class HoverButton : TextureButton
{
	private Label label;

	public override void _EnterTree()
	{
		MouseEntered += () => SetState(true);
		MouseExited += () => SetState(false);
	}

	public override void _Ready()
	{
		label = GetNode<Label>("Label");
	}

	private void SetState(bool hovered)
	{
		label.LabelSettings.FontColor = hovered ? new Color(1, 1, 1) : new Color(0, 0, 0);
	}
}