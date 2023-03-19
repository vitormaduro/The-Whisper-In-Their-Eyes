using Godot;
using System;

public partial class MainScene : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("%PageMarker").Pressed += PauseGame;
		GetNode<Button>("%UnpauseButton").Pressed += ResumeGame;
		GetNode<Control>("%PauseMenu").Visible = false;
		GetNode<RichTextLabel>("%History").Visible = false;
		GetNode<TextureRect>("%Static").Visible = false;

		GetNode<TextureButton>("QuickButtons/LogButton").Pressed += ToggleHistory;
		GetNode<TextureButton>("QuickButtons/NvlBoxButton").Pressed += ToggleText;
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("toggle_nvl_box"))
		{
			ToggleText();
		}
		else if(@event.IsActionPressed("toggle_history"))
		{
			ToggleHistory();
		}
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

	private void ToggleHistory()
	{
		var history = GetNode<RichTextLabel>("%History");

		history.Visible = !history.Visible;
		GetNode<RichTextLabel>("%TextArea").Visible = !history.Visible;
		SettingsManager.IsGamePaused = history.Visible;
	}

	private void ToggleText()
	{
		var nvlBox = GetNode<Control>("NVLBox");

		nvlBox.Visible = !nvlBox.Visible;
	}
}
