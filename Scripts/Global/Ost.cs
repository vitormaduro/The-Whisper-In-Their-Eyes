using Godot;

public partial class Ost : Node
{
	public AudioStreamOggVorbis Audio { get; set; }
	public string AudioName{ get; set; }

	public Ost(string name)
	{
		var res = "res:/";

		AudioName = name;
		Audio = (AudioStreamOggVorbis) GD.Load($"{res}/Audio/Soundtrack/{name}.ogg");
	}

	public Ost() { }
}
