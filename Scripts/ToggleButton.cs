using Godot;

public partial class ToggleButton : TextureButton
{
	public bool Selected { get; set; }

	public void SetSelected(bool selected)
	{
		ButtonPressed = selected;
		
		GetNode<Label>("Label").LabelSettings.FontColor = selected ? new Color(1, 1, 1) : new Color(0, 0, 0);
	}
}
