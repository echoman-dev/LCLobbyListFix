using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace LobbyListFix.Patches
{
    [HarmonyPatch(typeof(SteamLobbyManager))]
    internal class SteamLobbyManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void lobbyListPatch(ref Transform ___levelListContainer)
        {
            ___levelListContainer.GetChild(0).gameObject.SetActive(false);

            ContentSizeFitter contentSizeFitter = ___levelListContainer.gameObject.AddComponent<ContentSizeFitter>();
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;

            VerticalLayoutGroup verticalLayoutGroup = ___levelListContainer.gameObject.AddComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.spacing = 6;
            verticalLayoutGroup.childAlignment = TextAnchor.UpperLeft;

            verticalLayoutGroup.reverseArrangement = false;
            verticalLayoutGroup.childControlHeight = false;
            verticalLayoutGroup.childForceExpandHeight = true;
            verticalLayoutGroup.childForceExpandWidth = true;
        }
    }
}
