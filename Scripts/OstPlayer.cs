using System.Collections.Generic;
using Godot;

public partial class OstPlayer : AudioStreamPlayer
{
	private Dictionary<string, Ost> songs;

	public override void _Ready()
	{
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
		};
	}

	public string PlaySongByTag(string tag)
	{
		var song = songs[tag];

		Stream = song.Audio;
		Playing = true;

		return song.AudioName;
	}

	public void StopSong()
	{
		Playing = false;
	}
}
