using MorePrecisePlayerHeight.Models;

namespace MorePrecisePlayerHeight.Settings
{
	public class PluginConfig
	{
		public static PluginConfig Instance { get; set; } = null!;

		public virtual bool Enabled { get; set; } = true;
		public virtual HeightUnit HeightUnit { get; set; } = HeightUnit.Meters;
	}
}