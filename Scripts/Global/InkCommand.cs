using Godot;

public class InkCommand
{
	public string Command { get; set; }
	public int ParamsNumber { get; set; }
	public StringName Signal { get; set; }
	public bool CanAutoAdvance { get; set; } = true;
	public float DelayTime { get; set; } = 0.5f;
}
