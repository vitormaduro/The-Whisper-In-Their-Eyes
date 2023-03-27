using Godot;
using System.Collections.Generic;

public partial class SfxPlayer : AudioStreamPlayer
{
	private Dictionary<string, AudioStream> effects;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		cmdManager.SfxTriggered += (string tag) => PlayEffectByTag(tag);
		cmdManager.StaticTriggered += (string mode) => StaticEffect(mode);

		effects = new Dictionary<string, AudioStream>()
		{
			{ "static", GD.Load<AudioStreamWav>("res://Audio/Effects/static.sample") },
			{ "phone_ring", GD.Load<AudioStreamWav>("res://Audio/Effects/phone_ring.sample") },
			{ "phone_pickup", GD.Load<AudioStreamWav>("res://Audio/Effects/phone_pickup.sample") },
			{ "train_horn", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/train_horn.ogg") },
			{ "fly_buzz", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/fly_buzz.ogg") },
			{ "heart_thump", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heartbeat.ogg") },
			{ "ding_dong", GD.Load<AudioStreamWav>("res://Audio/Effects/doorbell.wav") },
			{ "ringing_noise", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/ringing_noise.ogg") },
			{ "woman_shriek", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_shriek.ogg") },
			{ "tv_tuning", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/tv_tuning.ogg") },
			{ "tv_changing", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/tv_changing.ogg") },
			{ "woman_vomit", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_vomit.ogg") },
			{ "clock_ticking", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/clock_ticking.ogg") },
			{ "man_cough", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_cough.ogg") },
			{ "slam_phone", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/slam_phone.ogg") },
			{ "mirror_shatter", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/mirror_shatter.ogg") },
			{ "woman_weep", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_weep.ogg") },
			{ "choking", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/choking.ogg") },
			{ "knock_wood", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/knock_wood.ogg") },
			{ "man_grunt_anger", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_grunt_anger.ogg") },
			{ "man_violent_cough", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_violent_cough.ogg") },
			{ "light_flicker", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/light_flicker.ogg") },
			{ "man_scream_echo", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_scream_echo.ogg") },
			{ "door_close", GD.Load<AudioStreamWav>("res://Audio/Effects/door_close.wav") },
			{ "claps", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/claps.ogg") },
			{ "heavy_gust", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heavy_gust.ogg") },
			{ "ghost_cry", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/ghost_cry.ogg") },
		};
	}

	public void PlayEffectByTag(string tag)
	{
		if(!effects.ContainsKey(tag))
		{
			GD.PushWarning($"Sound effect [{tag}] not implemented yet");

			return;
		}

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
