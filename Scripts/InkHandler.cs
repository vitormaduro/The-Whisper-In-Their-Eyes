using System.Linq;
using System.Threading.Tasks;
using Godot;
using GodotInk;

public partial class InkHandler : Node
{
	[Export] private InkStory story;

	[Signal] public delegate void CommandReceivedEventHandler(string commandName, string[] args);
	
	private InkCommandsManager cmdManager;

	public override void _Ready()
	{
		cmdManager = GetNode<InkCommandsManager>("%InkCommandsManager");

		story.ResetState();
		
		if(SaveManager.CurrentScene != null)
		{
			JumpToScene(SaveManager.CurrentScene);
		}
	}

	public void JumpToScene(string scene)
	{
		story.ChoosePathString($"Scene_{scene}");
	}

	public async Task<string> ContinueStory()
	{
		if(!story.CanContinue)
		{
			return null;
		}

		var line = "";

		do
		{
			line = story.Continue().Replace("\n", "");

			var tags = story.CurrentTags;

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

		return Tr(line);
	}
}
