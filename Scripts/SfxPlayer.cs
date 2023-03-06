using Godot;
using System.Collections.Generic;

public partial class SfxPlayer : AudioStreamPlayer
{
	private Dictionary<string, AudioStreamWav> effects;

	public override void _Ready()
	{
		effects = new Dictionary<string, AudioStreamWav>()
		{

		};

		base._Ready();
	}

	public void PlayEffectByTag(string tag)
	{
		Stream = effects[tag];
		Playing = true;
	}
}
