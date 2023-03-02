using System;
using System.Globalization;
using Godot;
using Godot.Collections;

public partial class SaveManager : Node
{
	private const string CURRENT_TAG = "CurrentTag";
	private const string DATE = "Date";
	private const string ACT = "Act";

	public static string CurrentTag { get; set; } = null;
	public static string CurrentAct { get; set; }
	public static DateTime SaveDate { get; private set; }
	public static DateTime LastSaveDate { get; private set; }

	public static void SaveGameAt(string saveFile)
	{
		using (var saveGame = FileAccess.Open($"user://{saveFile}.save", FileAccess.ModeFlags.Write))
		{
			var saveData = new Dictionary<string, string>()
			{
				{ CURRENT_TAG, CurrentTag },
				{ DATE, DateTime.Now.ToString("yyyyMMddHHmmss") },
				{ ACT, CurrentAct }
			};

			var json = Json.Stringify(saveData);

			saveGame.StoreLine(json);

			LastSaveDate = DateTime.Now;
		}
	}

	/// <summary>
    /// 	Loads a specified save file
    /// </summary>
	public void LoadQuickSave()
	{
		var nodeData = GetSaveFileData("quick");

		CurrentTag = nodeData[CURRENT_TAG];
		CurrentAct = nodeData[ACT];

		if(DateTime.TryParseExact(nodeData[DATE], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
		{
			SaveDate = date;
		}
	}

	public static void LoadSaveSlot(int slot)
	{
		var nodeData = GetSaveFileData($"slot_{slot}");

		SaveManager.CurrentTag = nodeData["CurrentTag"];
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
