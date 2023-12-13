using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LCEnumUtils
{
    [BepInPlugin(modGUID, modName, modVersion)]
    internal class Initializer : BaseUnityPlugin
    {
        private const string modGUID = "MegaPiggy.EnumUtils";
        private const string modName = "Enum Utils";
        private const string modVersion = "1.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Initializer Instance;

        private static ManualLogSource LoggerInstance => Instance.Logger;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            EnumUtils.Initialize(harmony, Logger);
            Logger.LogInfo($"Plugin {modName} is loaded with version {modVersion}!");
        }
    }
}
