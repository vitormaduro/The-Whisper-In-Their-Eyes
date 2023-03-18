using Godot;
using System.Collections.Generic;

public partial class SfxPlayer : AudioStreamPlayer
{
	private Dictionary<string, AudioStreamWav> effects;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		cmdManager.SfxTriggered += (string tag) => PlayEffectByTag(tag);
		cmdManager.StaticTriggered += (string mode) => StaticEffect(mode);

		effects = new Dictionary<string, AudioStreamWav>()
		{
			{ "static", GD.Load<AudioStreamWav>("res://Audio/Effects/static.sample") },
			{ "phone_ring", GD.Load<AudioStreamWav>("res://Audio/Effects/phone_ring.sample") },
			{ "phone_pickup", GD.Load<AudioStreamWav>("res://Audio/Effects/phone_pickup.sample") }
		};

		base._Ready();
	}

	public void PlayEffectByTag(string tag)
	{
		Stream = effects[tag];
		Playing = true;
	}

	public void StaticEffect(string mode)
	{
		bool.TryParse(mode, out var state);

		if(state)
		{
			PlayEffectByTag("static");
		}
		else
		{
			Playing = false;
		}
	}
}
