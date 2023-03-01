using Godot;

public partial class SettingsMenu : Control
{
	public void UpdateLanguage(int languageId)
	{
		var locale = languageId == 0 ? "en" : "pt_BR";

		SaveManager.Locale = locale;

		TranslationServer.SetLocale(locale);
		SaveManager.SaveSettings();
	}

	public void OnSettingsLoad()
	{
		GetNode<OptionButton>("MarginContainer/VBoxContainer/Language/LanguageSelect").Selected = SaveManager.Locale == "pt_BR" ? 1 : 0;
	}
}
