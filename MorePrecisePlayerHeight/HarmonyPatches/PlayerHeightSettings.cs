using HarmonyLib;
using TMPro;

namespace MorePrecisePlayerHeight.HarmonyPatches
{
	[HarmonyPatch(typeof(PlayerHeightSettingsController))]
	[HarmonyPatch("RefreshUI", MethodType.Normal)]
	class PlayerHeightSettings
	{
		static void Postfix(ref TextMeshProUGUI ____text, ref PlayerSpecificSettings ____playerSettings)
		{
			Plugin.Logger.Info($"{nameof(MorePrecisePlayerHeight)} postfix called" );

			____text.text = $"{(object) ____playerSettings.playerHeight:0.00}m";
		}
	}
}