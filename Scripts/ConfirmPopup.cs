using System;
using Godot;

public partial class ConfirmPopup : Control
{

	private TextureButton yesButton;
	private TextureButton noButton;

	public override void _Ready()
	{
		yesButton = GetNode<TextureButton>("%YesButton");
		noButton = GetNode<TextureButton>("%NoButton");

		noButton.Pressed += () => QueueFree();
	}

	public void SetYesButtonAction(Action action)
	{
		yesButton.Pressed += () =>
		{
			action.Invoke();
			QueueFree();
		};
	}
}
