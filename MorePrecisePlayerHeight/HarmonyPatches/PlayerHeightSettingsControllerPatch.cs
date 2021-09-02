using System;
using HarmonyLib;
using MorePrecisePlayerHeight.Models;
using MorePrecisePlayerHeight.Settings;
using TMPro;

namespace MorePrecisePlayerHeight.HarmonyPatches
{
	[HarmonyPatch(typeof(PlayerHeightSettingsController))]
	[HarmonyPatch(nameof(PlayerHeightSettingsController.RefreshUI), MethodType.Normal)]
	internal class PlayerHeightSettingsControllerPatch
	{
		private const double METERS_TO_FEET_CONVERSION_FACTOR = 0.3048;
		private const double METERS_TO_BANANA_CONVERSION_FACTOR = 100d / 13;

// ReSharper disable InconsistentNaming
		internal static bool Prefix(ref TextMeshProUGUI ____text, ref float ____value)
// ReSharper restore InconsistentNaming
		{
			if (!PluginConfig.Instance.Enabled)
			{
				return true;
			}

			switch (PluginConfig.Instance)
			{
				case { HeightUnit: HeightUnit.Meters }:
					____text.text = $"<size=80%>{____value:0.00}m</size>";
					return false;
				case { HeightUnit: HeightUnit.Feet }:
					var playerHeight = ____value;
					var inchFeet = playerHeight / METERS_TO_FEET_CONVERSION_FACTOR;
					var wholeFeet = (int) inchFeet;
					var inches = Math.Round((inchFeet - wholeFeet) / 0.0833);

					____text.text = $"<size=85%>{wholeFeet}'\n{inches:0.0}\"</size>";
					return false;
				case { HeightUnit: HeightUnit.Banana }:
					____text.text = $"<size=75%>{(____value * METERS_TO_BANANA_CONVERSION_FACTOR):0.00}\nbanana</size>";
					return false;
			}

			return true;
		}
	}
}