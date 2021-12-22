using System;
using System.Collections.Generic;
using System.Linq;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using MorePrecisePlayerHeight.Models;
using Zenject;

namespace MorePrecisePlayerHeight.Settings
{
	internal class SettingsController : IInitializable, IDisposable
	{
		private readonly PluginConfig _config;

		public SettingsController(PluginConfig config)
		{
			_config = config;
		}

		public void Initialize()
		{
			BSMLSettings.instance.AddSettingsMenu("<size=75%>More Precise PlayerHeight</size>", $"{nameof(MorePrecisePlayerHeight)}.{nameof(Settings)}.Settings.bsml", this);
		}

		public void Dispose()
		{
			BSMLSettings.instance.RemoveSettingsMenu(this);
		}

		[UIValue("enabled")]
		public bool Enabled
		{
			get => _config.Enabled;
			set => _config.Enabled = value;
		}

		[UIValue("heightUnitOptions")]
		public List<object> HeightUnitOptions = Enum.GetValues(typeof(HeightUnit)).Cast<object>().ToList();

		[UIValue("selectedHeightUnit")]
		public HeightUnit SelectedHeightUnit
		{
			get => _config.HeightUnit;
			set => _config.HeightUnit = value;
		}
	}
}