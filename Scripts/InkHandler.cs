using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;
using GodotInk;

public partial class InkHandler : Node
{
	[Export] private InkStory story;

	[Signal] public delegate void CommandReceivedEventHandler(string commandName, string[] args);
	[Signal] public delegate void StoryLoadedEventHandler();
	
	private InkCommandsManager cmdManager;

	public override void _Ready()
	{
		cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		story.ResetState();
		
		if(SaveManager.CurrentScene != null)
		{
			JumpToScene(SaveManager.CurrentScene);
		}

		EmitSignal(SignalName.StoryLoaded);
	}

	public void JumpToScene(string scene)
	{
		story.ChoosePathString($"Scene_{scene}");
	}

	public async Task<InkLine> ContinueStory()
	{
		var line = "";
		var tags = new List<string>();

		do
		{
			if(!story.CanContinue)
			{
				return null;
			}

			line = story.Continue().Replace("\n", "");
			tags = story.CurrentTags;

			if (tags.Any(t => t.StartsWith("SCENE:")))
			{
				SaveManager.CurrentScene = tags.Where(t => t.StartsWith("SCENE:")).First().Replace("SCENE:", "");
			}

			if(line.StartsWith(">>"))
			{
				var command = line.Replace(">> ", "").Split(' ');

				EmitSignal(SignalName.CommandReceived, command[0], command[1..]);

				await ToSignal(cmdManager, "CommandFinishedExecuting");
			}
		} 
		while(line.StartsWith(">>"));

		return new InkLine()
		{
			Line = Tr(line),
			Tags = tags
		};
	}
}
