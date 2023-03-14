using Godot;
using System;

public partial class MainScene : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("%PageMarker").Pressed += PauseGame;
		GetNode<Button>("%UnpauseButton").Pressed += ResumeGame;
		GetNode<Control>("%PauseMenu").Visible = false;

		base._Ready();
	}

	public void PauseGame()
	{
		SettingsManager.IsGamePaused = true;

		GetNode<Control>("%PauseMenu").Visible = true;
		GetNode<AnimationPlayer>("%AnimationPlayer").SpeedScale = 0;
	}

	public void ResumeGame()
	{
		SettingsManager.IsGamePaused = false;

		GetNode<Control>("%PauseMenu").Visible = false;

		GetNode<AnimationPlayer>("%AnimationPlayer").SpeedScale = 1;
	}
}
