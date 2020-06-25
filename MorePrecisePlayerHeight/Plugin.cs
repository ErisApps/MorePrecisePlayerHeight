using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Logging;

namespace MorePrecisePlayerHeight
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		private const string _harmonyId = "be.erisapps.morepreciseplayerheight"; 
		
		public static Harmony HarmonyInstance;
		public static Logger Logger;

		[Init]
		public void Init(IPA.Logging.Logger logger)
		{
			Logger = logger;
		}

		[OnEnable]
		public void OnStart()
		{
			Logger.Log(Logger.Level.Info, $"{nameof(MorePrecisePlayerHeight)} enabled" );
			HarmonyInstance = new Harmony(_harmonyId);
			HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		[OnDisable]
		public void OnDisable()
		{
			Logger.Log(Logger.Level.Info, $"{nameof(MorePrecisePlayerHeight)} disabled" );

			HarmonyInstance.UnpatchAll(_harmonyId);
		}
	}
}