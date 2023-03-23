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

		story.ObserveVariable("currentScene", Callable.From((string varName, Variant sceneNumber) => 
		{
			var scene = (string) sceneNumber;

			if(scene != "0")
			{
				SaveManager.CurrentScene = scene;
				SaveManager.CurrentStitch = null;

				GD.Print($"Entering scene [{SaveManager.CurrentScene}]");
			}
		}));

		story.ObserveVariable("currentStitch", Callable.From((string varName, Variant stitchNumber) => 
		{
			var stitch = (string) stitchNumber;

			if(stitch != "0")
			{
				SaveManager.CurrentStitch = stitch;

				GD.Print($"Entering stitch [{SaveManager.CurrentScene}.{SaveManager.CurrentStitch}]");
			}
		}));

		if(SaveManager.CurrentScene != null)
		{
			JumpToScene(SaveManager.CurrentScene, SaveManager.CurrentStitch);
		}
		else
		{
			JumpToScene("1");
		}

		EmitSignal(SignalName.StoryLoaded);
	}

	public void JumpToScene(string scene, string stitch = null)
	{
		story.ChoosePathString($"Scene_{scene}{(stitch != null ? $".stitch_{stitch}" : "")}");
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

			if(line.StartsWith(">>"))
			{
				var command = line.Replace(">> ", "").Split(' ');

				EmitSignal(SignalName.CommandReceived, command[0], command[1..]);

				await ToSignal(cmdManager, "CommandFinishedExecuting");
			}
		} 
		while(line.StartsWith(">>"));

		var translation = Tr(line);

		if(translation == line)
		{
			GD.PushWarning($"No translation found for tag [{translation}] (locale: [{SettingsManager.Locale}])");
		}

		return new InkLine()
		{
			Id = line,
			Line = translation,
			Tags = tags
		};
	}
}
