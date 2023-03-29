using Godot;

public partial class CreditsRoll : Control
{
	private const float SLIDE_TIME = 4f;

	public override void _Ready()
	{
		GetTree().CreateTimer(15 * SLIDE_TIME).Timeout += QueueFree;

		for (var i = 1; i <= 15; i++)
		{
			GetNode<Panel>($"Slide_{i}").Visible = false;

			var temp = i;

			GetTree().CreateTimer((temp - 1) * SLIDE_TIME).Timeout += () =>
			{
				GetNode<Panel>($"Slide_{temp}").Visible = true;
			};
		}
	}
}
