using System.Reflection;
using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using MorePrecisePlayerHeight.Settings;

namespace MorePrecisePlayerHeight
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		private const string HARMONY_ID = "be.erisapps.morepreciseplayerheight";
		private Harmony _harmonyInstance = null!;

		private SettingsController? _settingsController;

		[Init]
		public void Init(Config config)
		{
			PluginConfig.Instance = config.Generated<PluginConfig>();
		}

		[OnEnable]
		public void OnStart()
		{
			_settingsController ??= new SettingsController();
			BSMLSettings.instance.AddSettingsMenu("<size=75%>More Precise PlayerHeight</size>", $"{nameof(MorePrecisePlayerHeight)}.{nameof(Settings)}.Settings.bsml", _settingsController);

			_harmonyInstance = new Harmony(HARMONY_ID);
			_harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		[OnDisable]
		public void OnDisable()
		{
			_harmonyInstance.UnpatchAll(HARMONY_ID);

			BSMLSettings.instance.RemoveSettingsMenu(_settingsController);
			_settingsController = null!;
		}
	}
}