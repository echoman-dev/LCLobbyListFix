using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LobbyListFix.Patches;

namespace LobbyListFix
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInProcess("Lethal Company.exe")]
    [BepInIncompatibility("Ryokune.CompatibilityChecker")]
    [BepInIncompatibility("Ryokune.BetterLobbies")]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "io.github.echoman-dev.LCLobbyListFix";
        private const string modName = "Lethal Company Lobby List Fix";
        private const string modVersion = "0.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Plugin Instance;

        internal ManualLogSource logSource;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            logSource.LogInfo("Lobby List Fix Mod loaded.");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(SteamLobbyManagerPatch));
        }
    }
}
