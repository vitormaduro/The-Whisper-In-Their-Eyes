using System.Linq;
using Godot;
using GodotInk;

public partial class InkHandler : RichTextLabel
{
	[Export] private InkStory story;
	[Export] private int charactersPerSecond = 100;

	private double timer = 0f;
	private bool canType = true;

	public override void _Ready()
	{
		if(SaveManager.CurrentTag != null)
		{
			JumpToKnot(SaveManager.CurrentTag);
		}

		this.Text += ContinueStory();

		base._Ready();
	}

	public override void _Process(double delta)
	{
		timer += delta;

		if(canType && timer >= (1f / charactersPerSecond))
		{
			timer = 0f;

			this.VisibleCharacters++;

			if(this.VisibleRatio == 1)
			{
				canType = false;
			}
		}

		if(Input.IsActionJustPressed("text_advance"))
		{
			if(canType)
			{
				this.VisibleCharacters = this.GetTotalCharacterCount();
				canType = false;
			}
			else 
			{
				this.Text += ContinueStory();
				canType = true;
			}
		}
	}

	public void JumpToKnot(string knotName)
	{
		story.ChoosePathString(knotName);
	}

	private string ContinueStory()
	{
		var line = story.Continue();
		var tags = story.CurrentTags;

		if(tags.Any(t => t.StartsWith("KNOT")))
		{
			SaveManager.CurrentTag = tags.Where(t => t.StartsWith("KNOT")).First().Replace("KNOT:", "");
		}

		return Tr(line);
	}
}
