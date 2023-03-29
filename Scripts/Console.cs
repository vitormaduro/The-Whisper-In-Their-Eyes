using Godot;

public partial class Console : LineEdit
{
	private InkHandler inkScriptManager;

	public override void _Ready()
	{
		inkScriptManager = GetNode<InkHandler>("%InkScriptManager");

		TextSubmitted += (string text) => ExecuteCommand(text);
	}

	private void ExecuteCommand(string command)
	{
		Clear();

		var args = command.Split(' ');

		switch(args[0])
		{
			case "act":
				if(args.Length == 1)
				{
					GD.PushWarning("Invalid command: [act] requires 1 parameter");

					return;
				}

				JumpToAct(args[1]);
				break;
			
			case "scene":
				if(args.Length <= 2)
				{
					GD.PushWarning("Invalid command: [act] requires 2 parameters");

					return;
				}

				JumpToScene(args[1..]);
				break;
		}
	}

	private void JumpToScene(string[] args)
	{
		GD.Print($"Jumping to Scene [{args[0]}.{args[1]}]");

		inkScriptManager.JumpToScene(args[0], args[1]);
	}

	private void JumpToAct(string actNumber)
	{
		var scene = int.Parse(actNumber) switch
		{
			1 => "1",
			2 => "6",
			3 => "12",
			4 => "13",
			5 => "14",
			6 => "16",
			7 => "17",
			_ => null
		};

		if(scene == null)
		{
			GD.PushWarning($"Could not jump to Act [{actNumber}]: Invalid Number");

			return;
		}

		GD.Print($"Jumping to Act [{actNumber}] (Scene_{scene})");

		inkScriptManager.JumpToScene(scene);
	}
}
