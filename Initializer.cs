using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LCEnumUtils
{
    [BepInPlugin(PluginInfo.ModGUID, PluginInfo.ModName, PluginInfo.ModVersion)]
    internal class Initializer : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.ModGUID);

        private static Initializer Instance;

        private static ManualLogSource LoggerInstance => Instance.Logger;

        private void Awake()
        {
            if (Instance == null) Instance = this;

            EnumUtils.Initialize(harmony, Logger);
            Logger.LogInfo($"Plugin {PluginInfo.ModName} is loaded with version {PluginInfo.ModVersion}!");
        }
    }
}
