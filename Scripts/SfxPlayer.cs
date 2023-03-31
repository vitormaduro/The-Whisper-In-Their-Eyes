using Godot;
using System.Collections.Generic;
using static Godot.AudioStreamWav;

public partial class SfxPlayer : AudioStreamPlayer
{
	private Dictionary<string, AudioStream> effects;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");
		var inkManager = GetNode<InkHandler>("%InkScriptManager");

		cmdManager.SfxTriggered += (string tag) => PlayEffectByTag(tag);
		cmdManager.StaticTriggered += (string mode) => StaticEffect(mode);
		cmdManager.SfxTurnedOff += Stop;
		cmdManager.MultipleSfxTriggered += (string sfxList) => PlaySfxList(sfxList);
		inkManager.InkSceneChanged += Stop;

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
			{ "heavy_breathing", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heavy_breathing.ogg") },
			{ "heavy_breathing_loud", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heavy_breathing_loud.ogg") },
			{ "heavy_grunts", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heavy_grunts.ogg") },
			{ "heavy_grunts_loud", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heavy_grunts_loud.ogg") },
			{ "man_struggle", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_struggle.ogg") },
			{ "heart_thump_slow", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/heart_thump_slow.ogg") },
			{ "body_falling", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/body_falling.ogg") },
			{ "malevolent_laugh_multiple", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/malevolent_laugh_multiple.ogg") },
			{ "malevolent_woman", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/malevolent_woman.ogg") },
			{ "woman_here_low", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_low.ogg") },
			{ "woman_here_high", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_high.ogg") },
			{ "thousand_whispers", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/thousand_whispers.ogg") },
			{ "woman_right_here", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_right_here.ogg") },
			{ "woman_here_here_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_here_left.ogg") },
			{ "woman_here_here_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_here_right.ogg") },
			{ "woman_here_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_left.ogg") },
			{ "woman_here_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_right.ogg") },
			{ "door_creak", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/door_creak.ogg") },
			{ "woman_no_here_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_no_here_right.ogg") },
			{ "woman_no_here_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_no_here_left.ogg") },
			{ "woman_yes_here_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_yes_here_left.ogg") },
			{ "woman_come_here_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_come_here_right.ogg") },
			{ "woman_not_supposed_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_not_supposed_left.ogg") },
			{ "man_painful_scream", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_painful_scream.ogg") },
			{ "woman_door_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_door_left.ogg") },
			{ "woman_front_door_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_front_door_right.ogg") },
			{ "woman_can_escape_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_can_escape_left.ogg") },
			{ "woman_just_escape_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_just_escape_right.ogg") },
			{ "woman_here_both", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_here_both.ogg") },
			{ "woman_above", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/woman_above.ogg") },
			{ "tongue_licking", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/tongue_licking.ogg") },
			{ "knock_door", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/knock_door.ogg") },
			{ "laughter", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/laughter.ogg") },
			{ "whistle", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/whistle.ogg") },
			{ "man_turn_back_left", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_turn_back_left.ogg") },
			{ "man_turn_back_right", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_turn_back_right.ogg") },
			{ "ketuk_cackle", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/ketuk_cackle.ogg") },
			{ "man_turn_back_both", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/man_turn_back_both.ogg") },
			{ "phone_slam", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/phone_slam.ogg") },
			{ "plates_down", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/plates_down.ogg") },
			{ "thing_on_ceiling", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/thing_on_ceiling.ogg") },
			{ "break_stuff", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/break_stuff.ogg") },
			{ "walk_away", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/walk_away.ogg") },
			{ "oooo", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/oooo.ogg") },
			{ "walk_down_stairs", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/walk_down_stairs.ogg") },
			{ "run_down_stairs", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/run_down_stairs.ogg") },
			{ "bag_down", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/bag_down.ogg") },
			{ "leg_flop", GD.Load<AudioStreamOggVorbis>("res://Audio/Effects/leg_flop.ogg") },
		};
	}

	private void PlaySfxList(string sfxList)
	{
		var list = sfxList.Split('/');

		foreach(var sfx in list)
		{
			if(!effects.ContainsKey(sfx))
			{
				GD.PushWarning($"Sound effect [{sfx}] not implemented yet");

				continue;
			}

			var player = new AudioStreamPlayer();
			var effect = effects[sfx];

			if(effect is AudioStreamOggVorbis ogg)
			{
				ogg.Loop = false;
				player.Stream = ogg;
			}
			else if(effect is AudioStreamWav wav)
			{
				wav.LoopMode = LoopModeEnum.Disabled;
				player.Stream = wav;
			}

			GetParent().AddChild(player);

			player.Bus = "Sfx";
			player.Playing = true;
			player.Finished += player.QueueFree;
		}
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
