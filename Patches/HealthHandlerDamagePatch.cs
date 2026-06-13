using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BepInEx.Logging;
using HarmonyLib;
using TheShitMod.Components;
using UnityEngine;

namespace TheShitMod.Patches
{
    [HarmonyPatch(typeof(HealthHandler))]
    [HarmonyPatch(nameof(HealthHandler.DoDamage))]
    class HealthHandlerDamagePatch
    {
        static AccessTools.FieldRef<HealthHandler, CharacterData> m_data = AccessTools.FieldRefAccess<HealthHandler, CharacterData>("data");
        static AccessTools.FieldRef<HealthHandler, bool> m_isRespawning = AccessTools.FieldRefAccess<HealthHandler, bool>("isRespawning");

        static void Postfix(HealthHandler __instance, ref Vector2 damage, ref Vector2 position, ref Color blinkColor, ref GameObject damagingWeapon, ref Player damagingPlayer, ref bool healthRemoval, ref bool lethal, ref bool ignoreBlock)
        {
            if (damagingPlayer == null) return;

            if (damagingPlayer.GetComponent<IsFallingOverComponent>() != null)
            {
                // if we are not the main player, return
                if (m_data(__instance).GetComponent<GeneralInput>().controlledElseWhere) return;

                if (!m_data(__instance).isPlaying) return;
                if (m_data(__instance).dead) return;
                if (m_data(__instance).block.IsBlocking() && !ignoreBlock) return;
                if (m_isRespawning(__instance)) return;

                Camera.main.gameObject.transform.Rotate(new Vector3(0f, 0f, 10f));
            }

            if (damagingPlayer.GetComponent<IsSwappingHandsComponent>() != null)
            {
                // dont do this once per player since that might fuck things up
                if (m_data(__instance).GetComponent<GeneralInput>().controlledElseWhere) return;

                if (!m_data(__instance).isPlaying) return;
                if (m_data(__instance).dead) return;
                if (m_data(__instance).block.IsBlocking() && !ignoreBlock) return;
                if (m_isRespawning(__instance)) return;

                m_data(__instance).player.gameObject.GetComponent<PlayerCollision>().IgnoreWallForFrames(3);
                damagingPlayer.gameObject.GetComponent<PlayerCollision>().IgnoreWallForFrames(3);

                (m_data(__instance).player.gameObject.transform.position, damagingPlayer.gameObject.transform.position) = (damagingPlayer.gameObject.transform.position, m_data(__instance).player.gameObject.transform.position);
            }

            if (damagingPlayer.GetComponent<WashingMachineLicenseComponent>())
            {
                m_data(__instance).player.gameObject.AddComponent<BeingWashedComponent>();
            }
        }
    }
}
