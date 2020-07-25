using MorePrecisePlayerHeight.Models;

namespace MorePrecisePlayerHeight.Settings
{
	public class PluginConfig
	{
		public static PluginConfig Instance { get; set; }

		public virtual bool Enabled { get; set; } = true;
		public virtual HeightUnit HeightUnit { get; set; } = HeightUnit.Meters;
	}
}