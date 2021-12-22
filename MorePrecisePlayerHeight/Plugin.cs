using IPA;
using IPA.Config;
using IPA.Config.Stores;
using MorePrecisePlayerHeight.Installers;
using MorePrecisePlayerHeight.Settings;
using SiraUtil.Zenject;

namespace MorePrecisePlayerHeight
{
	[Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
	public class Plugin
	{
		[Init]
		public Plugin(Config config, Zenjector zenject)
		{
			zenject.Install<MPPHMenuInstaller>(Location.Menu, config.Generated<PluginConfig>());
		}
	}
}