using Godot;

public partial class Credits : Control
{
	public override void _Ready()
	{
		GetNode<TextureButton>("BackButton").Pressed += QueueFree;
	}
}
