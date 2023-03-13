using Godot;

public partial class ToggleButton : TextureButton
{
	public bool Selected { get; set; }

	public void SetSelected(bool selected)
	{
		var res = "res:/";
		var textureIdle = GD.Load<Texture2D>($"{res}/Art/UI/Settings/button_idle.png");
		var textureSelected = GD.Load<Texture2D>($"{res}/Art/UI/Settings/button_selected.png");

		if(selected)
		{
			TextureNormal = textureSelected;
			GetNode<Label>("Label").LabelSettings.FontColor = new Color(1, 1, 1);
		}
		else
		{
			TextureNormal = textureIdle;
			GetNode<Label>("Label").LabelSettings.FontColor = new Color(0, 0, 0);
		}
	}
}
