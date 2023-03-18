using Godot;
using System;

public partial class AnimationManager : AnimationPlayer
{
	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		cmdManager.ScreenIsShaking += (string mode) => PlayAnimation("screen_shake", mode);
		cmdManager.StaticTriggered += (string mode) => StaticEffect(mode);
		cmdManager.OstStarted += (string song) => FadeOstVolume("fade_in");
		cmdManager.OstStoped += () => FadeOstVolume("fade_out");
	}

	private void PlayAnimation(string animation, string mode)
	{
		bool.TryParse(mode, out var state);

		if(state)
		{
			Play(animation);
		}
		else
		{
			Stop();
			Play("RESET");
		}
	}

	private void StaticEffect(string mode)
	{
		bool.TryParse(mode, out var state);

		if(state)
		{
			Play("static_on");
		}
		else
		{
			Play("static_off");
		}
	}

	private void FadeOstVolume(string fadeType)
	{
		Play($"{fadeType}_ost");
	}
}
