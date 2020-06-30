using System;
using System.Collections.Generic;
using System.Linq;
using BeatSaberMarkupLanguage.Attributes;
using MorePrecisePlayerHeight.Models;
using UnityEngine;

namespace MorePrecisePlayerHeight.Settings
{
	public class SettingsController : MonoBehaviour
	{
		public static SettingsController Instance;

		public void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(this);
			}
		}

		[UIValue("enabled")]
		public bool Enabled
		{
			get => PluginConfig.Instance.Enabled;
			set => PluginConfig.Instance.Enabled = value;
		}

		[UIValue("heightUnitOptions")]
		public List<object> HeightUnitOptions = Enum.GetValues(typeof(HeightUnit)).Cast<object>().ToList();

		[UIValue("selectedHeightUnit")]
		public HeightUnit SelectedHeightUnit
		{
			get => PluginConfig.Instance.HeightUnit;
			set => PluginConfig.Instance.HeightUnit = value;
		}
		
		 
	}
}