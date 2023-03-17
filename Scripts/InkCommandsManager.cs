using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class InkCommandsManager : Control
{
	[Signal] public delegate void CommandFinishedExecutingEventHandler();

	[Signal] public delegate void BackgroundChangedEventHandler(string bgName);
	[Signal] public delegate void BackgroundStartedFlashingEventHandler(string bg1, string bg2);
	[Signal] public delegate void BackgroundStoppedFlashingEventHandler();
	[Signal] public delegate void TextClearedEventHandler();
	[Signal] public delegate void OstStartedEventHandler(string tag);
	[Signal] public delegate void OstStopedEventHandler();
	[Signal] public delegate void SpriteAppearedEventHandler(string characterTag, string spriteTag, string position);
	[Signal] public delegate void SfxTriggeredEventHandler(string tag);
	[Signal] public delegate void SpritesWereClearedEventHandler();
	[Signal] public delegate void DisclaimerDisplayedEventHandler(string line);
	[Signal] public delegate void ScreenClearedEventHandler();
	[Signal] public delegate void ScreenIsShakingEventHandler(string mode);
	[Signal] public delegate void BackgroundWasZoomedInEventHandler(string pivotX, string pivotY);
	[Signal] public delegate void BackgroundWasZoomedOutEventHandler();
	[Signal] public delegate void SpriteWasZoomedInEventHandler(string position, string pivotX, string pivotY);
	[Signal] public delegate void SpriteWasZoomedOutEventHandler(string position);
	[Signal] public delegate void StaticTriggeredEventHandler(string mode);

	private List<InkCommand> commands;
	private bool commandAwaitingInput;

	public override void _Ready()
	{
		GetNode<InkHandler>("%InkScriptManager").CommandReceived += (string commandName, string[] args) => ExecuteCommand(commandName, args);

		commands = new List<InkCommand>()
		{
			new InkCommand()
			{
				Command = "change_bg",
				Signal = SignalName.BackgroundChanged,
				ParamsNumber = 1
			},
			new InkCommand()
			{
				Command = "start_flash_bg",
				Signal = SignalName.BackgroundStartedFlashing,
				ParamsNumber = 2,
				DelayTime = 2
			},
			new InkCommand()
			{
				Command = "stop_flash_bg",
				Signal = SignalName.BackgroundStoppedFlashing,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "clear_text",
				Signal = SignalName.TextCleared,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "ost_on",
				Signal = SignalName.OstStarted,
				ParamsNumber = 1
			},
			new InkCommand()
			{
				Command = "ost_off",
				Signal = SignalName.OstStoped,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "sprite",
				Signal = SignalName.SpriteAppeared,
				ParamsNumber = 3
			},
			new InkCommand()
			{
				Command = "sfx",
				Signal = SignalName.SfxTriggered,
				ParamsNumber = 1
			},
			new InkCommand()
			{
				Command = "clear_sprites",
				Signal = SignalName.SfxTriggered,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "disclaimer",
				Signal = SignalName.DisclaimerDisplayed,
				ParamsNumber = 1,
				CanAutoAdvance = false
			},
			new InkCommand()
			{
				Command = "clear_all",
				Signal = SignalName.ScreenCleared,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "screen_shake",
				Signal = SignalName.ScreenIsShaking,
				ParamsNumber = 1
			},
			new InkCommand()
			{
				Command = "bg_zoom_in",
				Signal = SignalName.BackgroundWasZoomedIn,
				ParamsNumber = 2
			},
			new InkCommand()
			{
				Command = "bg_zoom_out",
				Signal = SignalName.BackgroundWasZoomedOut,
				ParamsNumber = 0
			},
			new InkCommand()
			{
				Command = "sprite_zoom_in",
				Signal = SignalName.SpriteWasZoomedIn,
				ParamsNumber = 3
			},
			new InkCommand()
			{
				Command = "sprite_zoom_out",
				Signal = SignalName.SpriteWasZoomedOut,
				ParamsNumber = 1
			},
			new InkCommand()
			{
				Command = "static",
				Signal = SignalName.StaticTriggered,
				ParamsNumber = 1,
				DelayTime = 0.3f
			}
		};
	}

	private void ExecuteCommand(string commandName, string[] args)
	{
		var cmd = commands.Where(c => c.Command == commandName).FirstOrDefault();

		if(cmd == null)
		{
			GD.PrintErr($"Command [{commandName}] not found");

			return;
		}

		switch(cmd.ParamsNumber)
		{
			case 1:
				EmitSignal(cmd.Signal, args[0]);
				break;

			case 2:
				EmitSignal(cmd.Signal, args[0], args[1]);
				break;

			case 3:
				EmitSignal(cmd.Signal, args[0], args[1], args[2]);
				break;

			default:
				EmitSignal(cmd.Signal);
				break;
		}

		if(cmd.CanAutoAdvance)
		{
			GetTree().CreateTimer(cmd.DelayTime).Timeout += () => EmitSignal(SignalName.CommandFinishedExecuting);
		}
		else 
		{
			commandAwaitingInput = true;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("text_advance"))
		{
			if(commandAwaitingInput)
			{
				EmitSignal(SignalName.CommandFinishedExecuting);

				commandAwaitingInput = false;
			}
		}
	}
}
