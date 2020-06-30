using System.Reflection;
using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using MorePrecisePlayerHeight.Settings;
using UnityEngine;
using Logger = IPA.Logging.Logger;

namespace MorePrecisePlayerHeight
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		private const string _harmonyId = "be.erisapps.morepreciseplayerheight";

		public static Harmony HarmonyInstance;
		public static Logger Logger;

		private SettingsController _settingsGo;

		[Init]
		public void Init(Logger logger, Config config)
		{
			Logger = logger;

			PluginConfig.Instance = config.Generated<PluginConfig>();
		}

		[OnEnable]
		public void OnStart()
		{
			Logger.Log(Logger.Level.Info, $"{nameof(MorePrecisePlayerHeight)} enabled");

			_settingsGo = new GameObject($"[{nameof(MorePrecisePlayerHeight)} settings go instance]").AddComponent<SettingsController>();
			Object.DontDestroyOnLoad(_settingsGo);
			BSMLSettings.instance.AddSettingsMenu("<size=75%>More Precise\nPlayerHeight</size>", $"{nameof(MorePrecisePlayerHeight)}.{nameof(Settings)}.Settings.bsml", _settingsGo);

			HarmonyInstance = new Harmony(_harmonyId);
			HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		[OnDisable]
		public void OnDisable()
		{
			Logger.Log(Logger.Level.Info, $"{nameof(MorePrecisePlayerHeight)} disabled");

			HarmonyInstance.UnpatchAll(_harmonyId);

			BSMLSettings.instance.RemoveSettingsMenu(_settingsGo);
			Object.DestroyImmediate(_settingsGo);
		}
	}
}