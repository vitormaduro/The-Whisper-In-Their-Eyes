using System;
using System.Globalization;
using Godot;
using Godot.Collections;

public partial class SaveManager : Node
{
	private const string CURRENT_SCENE = "CurrentScene";
	private const string CURRENT_STITCH = "CurrentStitch";
	private const string DATE = "Date";
	private const string CURRENT_BG = "CurrentBg";
	private const string STAGE_LEFT = "StageLeft";
	private const string STAGE_MIDDLE = "StageMiddle";
	private const string STAGE_RIGHT = "StageRight";
	private const string CURRENT_OST = "CurrentOst";

	public static string CurrentScene { get; set; } = null;
	public static string CurrentStitch { get; set; } = null;
	public static string CurrentBg { get; set; } = null;
	public static string CurrentOst { get; set; } = null;
	public static DateTime SaveDate { get; private set; }
	public static DateTime LastSaveDate { get; private set; }
	public static (string, string) StageLeft { get; set; }
	public static (string, string) StageMiddle { get; set; }
	public static (string, string) StageRight { get; set; }

	public static void SaveGameAt(string saveFile)
	{
		using (var saveGame = FileAccess.Open($"user://{saveFile}.save", FileAccess.ModeFlags.Write))
		{
			var saveData = new Dictionary<string, string>()
			{
				{ CURRENT_SCENE, CurrentScene },
				{ DATE, DateTime.Now.ToString("yyyyMMddHHmmss") },
				{ CURRENT_BG, CurrentBg },
				{ CURRENT_STITCH, CurrentStitch },
				{ CURRENT_OST, CurrentOst },
				{ STAGE_LEFT, $"{StageLeft.Item1}/{StageLeft.Item2}" },
				{ STAGE_MIDDLE, $"{StageMiddle.Item1}/{StageMiddle.Item2}" },
				{ STAGE_RIGHT, $"{StageRight.Item1}/{StageRight.Item2}" },
			};

			var json = Json.Stringify(saveData);

			saveGame.StoreLine(json);

			LastSaveDate = DateTime.Now;
		}
	}

	/// <summary>
    /// 	Loads a specified save file
    /// </summary>
	public static void LoadQuickSave()
	{
		var nodeData = GetSaveFileData("quick");

		CurrentScene = nodeData[CURRENT_SCENE];
		CurrentStitch = nodeData[CURRENT_STITCH];
		CurrentBg = nodeData[CURRENT_BG];
		CurrentOst = nodeData[CURRENT_OST];

		var charLeft = nodeData[STAGE_LEFT].Split('/');
		var charMiddle = nodeData[STAGE_MIDDLE].Split('/');
		var charRight = nodeData[STAGE_RIGHT].Split('/');

		StageLeft = (charLeft[0], charLeft[1]);
		StageMiddle = (charMiddle[0], charMiddle[1]);
		StageRight = (charRight[0], charRight[1]);

		if(DateTime.TryParseExact(nodeData[DATE], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
		{
			SaveDate = date;
		}
	}

	public static void ResetSaveSettings()
	{
		CurrentScene = CurrentStitch = null;
		StageLeft = StageMiddle = StageRight = (null, null);
		CurrentBg = null;
		CurrentOst = null;
	}

	public static void LoadSaveSlot(int slot)
	{
		var nodeData = GetSaveFileData($"slot_{slot}");

		CurrentScene = nodeData[CURRENT_SCENE];
		CurrentStitch = nodeData[CURRENT_STITCH];
		CurrentBg = nodeData[CURRENT_BG];
		CurrentOst = nodeData[CURRENT_OST];

		var charLeft = nodeData[STAGE_LEFT].Split('/');
		var charMiddle = nodeData[STAGE_MIDDLE].Split('/');
		var charRight = nodeData[STAGE_RIGHT].Split('/');

		StageLeft = (charLeft[0], charLeft[1]);
		StageMiddle = (charMiddle[0], charMiddle[1]);
		StageRight = (charRight[0], charRight[1]);

		if(DateTime.TryParseExact(nodeData[DATE], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
		{
			SaveDate = date;
		}
	}

	public static Dictionary<string, string> GetSaveFileData(string fileName)
	{
		using(var saveGame = FileAccess.Open($"user://{fileName}.save", FileAccess.ModeFlags.Read))
		{
			if(saveGame == null)
			{
				return null;
			}

			var jsonString = saveGame.GetLine();
			var json = new Json();
			var parseResult = json.Parse(jsonString);

			return new Dictionary<string, string>((Dictionary) json.Data);
		}
	}
}
