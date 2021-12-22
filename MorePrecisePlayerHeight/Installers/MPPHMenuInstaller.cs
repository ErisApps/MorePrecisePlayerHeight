using MorePrecisePlayerHeight.HarmonyPatches;
using MorePrecisePlayerHeight.Settings;
using Zenject;

namespace MorePrecisePlayerHeight.Installers
{
	// ReSharper disable once InconsistentNaming
	internal sealed class MPPHMenuInstaller : Installer
	{
		private readonly PluginConfig _config;

		public MPPHMenuInstaller(PluginConfig config)
		{
			_config = config;
		}

		public override void InstallBindings()
		{
			Container.BindInstance(_config);
			Container.BindInterfacesTo<SettingsController>().AsSingle();

			Container.BindInterfacesTo<PlayerHeightSettingsControllerPatch>().AsSingle();
		}
	}
}