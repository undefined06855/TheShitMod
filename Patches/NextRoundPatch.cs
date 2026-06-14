using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using TheShitMod.Components;
using UnityEngine;

namespace TheShitMod.Patches
{
    [HarmonyPatch(typeof(MapManager))]
    [HarmonyPatch(nameof(MapManager.CallInNewMapAndMovePlayers))]
    class NextRoundPatch
    {
        static void Postfix(MapManager __instance, ref int mapID)
        {
            UnityEngine.Debug.Log("CallInNewMap called");

            // fuck im falling over
            Camera.main.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);

            // random damage
            foreach (var player in PlayerManager.instance.players)
            {
                var component = player.GetComponent<IsRandomDamageComponent>();
                if (component == null) continue;

                var r = new System.Random();
                var dmg = Mathf.Clamp((float)r.NextDouble() + 0.5f, 0.5f, 1.5f);
                player.data.weaponHandler.gun.damage *= dmg;
                component.m_totalDamageMultiplied *= dmg;

                // keep first line if relevant and append multiplier
                // crown text seems to be synced globally between all players?
                // probably shouldnt be using this
                // okay i think i know why it's because i stored the IsRandomDamageComponent so it was global?

                CrownPos crown = (CrownPos)typeof(CharacterData).GetField("crownPos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(player.data);
                string text = crown.text.text;

                int newlineIndex = text.IndexOf('\n');
                if (newlineIndex >= 0)
                {
                    text = text[..newlineIndex] + "\n";
                }
                else
                {
                    text = "";
                }

                text += String.Format("x{0:0.000000000000000000}", component.m_totalDamageMultiplied);
                crown.text.text = text;
            }
        }
    }
}
