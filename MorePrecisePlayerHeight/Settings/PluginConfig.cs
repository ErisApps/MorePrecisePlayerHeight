using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using MorePrecisePlayerHeight.Models;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace MorePrecisePlayerHeight.Settings
{
	internal class PluginConfig
	{
		public virtual bool Enabled { get; set; } = true;
		public virtual HeightUnit HeightUnit { get; set; } = HeightUnit.Meters;
	}
}