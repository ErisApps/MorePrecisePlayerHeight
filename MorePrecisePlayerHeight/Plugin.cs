﻿using System.Reflection;
using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using MorePrecisePlayerHeight.Settings;
using Logger = IPA.Logging.Logger;

namespace MorePrecisePlayerHeight
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		private const string HarmonyId = "be.erisapps.morepreciseplayerheight";
		private Harmony _harmonyInstance;

		private SettingsController _settingsController;

		internal static Logger Logger;

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

			_settingsController ??= new SettingsController();
			BSMLSettings.instance.AddSettingsMenu("<size=75%>More Precise\nPlayerHeight</size>", $"{nameof(MorePrecisePlayerHeight)}.{nameof(Settings)}.Settings.bsml", _settingsController);

			_harmonyInstance = new Harmony(HarmonyId);
			_harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		[OnDisable]
		public void OnDisable()
		{
			Logger.Log(Logger.Level.Info, $"{nameof(MorePrecisePlayerHeight)} disabled");

			_harmonyInstance.UnpatchAll(HarmonyId);

			BSMLSettings.instance.RemoveSettingsMenu(_settingsController);
			_settingsController = null;
		}
	}
}