using System.Collections.Generic;
using Godot;

public partial class CreditsRoll : Control
{
	private const float SLIDE_TIME = 11f;
	private const int SLIDE_NUMBER = 16;

	private ProgressBar skipBar;
	private List<Timer> timers = new List<Timer>();
	private bool skipped = false;

	public override void _Ready()
	{
		SettingsManager.IsGalleryUnlocked = true;
		SettingsManager.SaveSettings();

		skipBar = GetNode<ProgressBar>("ProgressBar");

		for (var i = 1; i <= SLIDE_NUMBER; i++)
		{
			GetNode<Panel>($"Slide_{i}").Visible = false;

			var temp = i;
			var timer = new Timer()
			{
				WaitTime = Mathf.Max(0.01f, (temp - 1) * SLIDE_TIME),
				OneShot = true,
				Autostart = true
			};

			AddChild(timer);

			timer.Timeout += () =>
			{
				GetNode<Panel>($"Slide_{temp}").Visible = true;

				if(temp == SLIDE_NUMBER)
				{
					GetTree().CreateTimer(30).Timeout += () =>
					{
						GetTree().ChangeSceneToFile("res://Scenes/main_menu.scn");
						QueueFree();
					};
				}
			};

			timers.Add(timer);
		}
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("return"))
		{
			skipBar.Value += delta;
		}
		else
		{
			skipBar.Value -= delta;
		}

		if(skipBar.Value == skipBar.MaxValue && !skipped)
		{
			skipped = true;

			timers.ForEach(t => t.QueueFree());

			GetNode<Panel>("Slide_16").Visible = true;

			GetTree().CreateTimer(5).Timeout += QueueFree;
		}
	}
}
