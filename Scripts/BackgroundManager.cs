using Godot;

public partial class BackgroundManager : TextureRect
{
	private Timer backgroundTimer;
	private string currentBg;

	public override void _Ready()
	{
		var cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		backgroundTimer = GetNode<Timer>("BackgroundTimer");

		cmdManager.BackgroundStartedFlashing += (string bg1, string bg2) => StartFlashBackground(bg1, bg2);
		cmdManager.BackgroundStoppedFlashing += StopFlashBackground;
		cmdManager.BackgroundChanged += (string bgName) => ChangeBackground(bgName);
		cmdManager.DisclaimerDisplayed += (string line) => ChangeBackground("black");
		cmdManager.BackgroundWasZoomedIn += (string pivotX, string pivotY, string scale) => ZoomIn(pivotX, pivotY, scale);
		cmdManager.BackgroundWasZoomedOut += ZoomOut;
		cmdManager.SlowZoomWasTriggered += (string pivotX, string pivotY, string scale) => SlowZoomIn(pivotX, pivotY, scale);
	}

	private void StartFlashBackground(string bg1, string bg2)
	{
		backgroundTimer.Timeout += () =>
		{
			ChangeBackground(currentBg == bg1 ? bg2 : bg1);
		};

		backgroundTimer.Start();
	}

	private void StopFlashBackground()
	{
		backgroundTimer.Stop();
		backgroundTimer.WaitTime = 0.5f;
	}

	private void ChangeBackground(string backgroundName)
	{
		Texture = GD.Load<Texture2D>($"res://Art/Backgrounds/{(backgroundName)}.jpg");

		currentBg = backgroundName;
	}

	private void ZoomIn(string pivotX, string pivotY, string scale)
	{
		var s = float.Parse(scale);

		PivotOffset = new Vector2(float.Parse(pivotX), float.Parse(pivotY));
		Scale = new Vector2(s, s);
	}

	private void ZoomOut()
	{
		PivotOffset = new Vector2(0, 0);
		Scale = new Vector2(1, 1);
	}

	private void SlowZoomIn(string pivotX, string pivotY, string scale)
	{
		var s = float.Parse(scale);
		var tween = CreateTween();

		PivotOffset = new Vector2(float.Parse(pivotX), float.Parse(pivotY));

		tween.TweenProperty(GetNode<TextureRect>("%BackgroundImage"), "scale", new Vector2(s, s), 5);
	}
}
