using MorePrecisePlayerHeight.Models;

namespace MorePrecisePlayerHeight.Settings
{
	public class PluginConfig
	{
		public static PluginConfig Instance { get; set; }

		public bool Enabled { get; set; } = true;
		public HeightUnit HeightUnit { get; set; } = HeightUnit.Meters;
	}
}