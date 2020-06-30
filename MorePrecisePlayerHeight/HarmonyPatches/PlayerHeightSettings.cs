using HarmonyLib;
using TMPro;

namespace MorePrecisePlayerHeight.HarmonyPatches
{
	[HarmonyPatch(typeof(PlayerHeightSettingsController))]
	[HarmonyPatch("RefreshUI", MethodType.Normal)]
	class PlayerHeightSettings
	{
		static bool Prefix(ref TextMeshProUGUI ____text, ref PlayerSpecificSettings ____playerSettings)
		{
						____text.text = $"{(object) ____playerSettings.playerHeight:0.00}m";
						return false;

		}
	}
}