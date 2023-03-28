using System.Collections.Generic;
using Godot;
using static Godot.Tween;

public partial class OstPlayer : AudioStreamPlayer
{
	private Dictionary<string, Ost> songs;

	public override void _Ready()
	{
		GetNode<Label>("OstInfo").Visible = false;

		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		cmdManager.OstStarted += (string tag) => PlaySongByTag(tag);
		cmdManager.OstStoped += StopSong;

		songs = new Dictionary<string, Ost>()
		{
			{ "croak", new Ost("A Dying Man's Croak") },
			{ "agony", new Ost("The Ecstasy Of Crushing Agony") },
			{ "photo1", new Ost("A photograph") },
			{ "photo2", new Ost("A Photograph (reprise)") },
			{ "lost", new Ost("Lost and Not Found") },
			{ "illness", new Ost("Growing Illness") },
			{ "old_man", new Ost("For Our Old Men") },
			{ "children", new Ost("For Our Children") }
		};

		if(SaveManager.CurrentOst != null)
		{
			PlaySongByTag(SaveManager.CurrentOst);
		}
	}

	public void PlaySongByTag(string tag)
	{
		if(!songs.ContainsKey(tag))
		{
			GD.PushWarning($"Song [{tag}] not implemented yet");

			return;
		}

		SaveManager.CurrentOst = tag;

		var song = songs[tag];

		Stream = song.Audio;
		Playing = true;

		var infoCard = GetNode<Label>("OstInfo");
		var tween = CreateTween().SetParallel(true).SetEase(EaseType.In);

		infoCard.Visible = true;
		infoCard.Text = song.AudioName;

		tween.TweenProperty(infoCard, "position", new Vector2(0, 986), 0.5f);
		tween.TweenProperty(this, "volume_db", -10, 1);
		tween.TweenInterval(2f);
		tween.Chain().TweenProperty(infoCard, "position", new Vector2(0, 1080), 0.5f);

		GetTree().CreateTimer(2).Timeout += () =>
		{
			infoCard.Visible = false;
		};
	}

	public void StopSong()
	{
		SaveManager.CurrentOst = null;
		
		var infoCard = GetNode<Label>("OstInfo");
		var tween = CreateTween().SetParallel(true);

		tween.TweenProperty(this, "volume_db", -40, 1);

		GetTree().CreateTimer(1).Timeout += () =>
		{
			Playing = false;
		};
	}
}
