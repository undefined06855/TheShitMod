using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using TheShitMod.Components;
using UnityEngine;

namespace TheShitMod.Patches
{
    [HarmonyPatch(typeof(Transform))]
    [HarmonyPatch(nameof(Transform.rotation))]
    [HarmonyPatch(MethodType.Setter)]
    class FuckMapEmbiggenerPatch
    {
        static bool Prefix(Transform __instance)
        {
            if (__instance.gameObject != Camera.main.gameObject) return true;

            var currentStack = new System.Diagnostics.StackTrace(true);
            var stackString = currentStack.ToString();
            stackString = stackString.Replace("TheShitMod.Patches.FuckMapEmbiggenerPatch", "");
            if (!stackString.Contains("TheShitMod"))
            {
                // FIRE SOLUTIONS PEOPLE!!!
                // (MapEmbiggener sets the rotation of the camera every frame)
                return false; // don't set the rotation
            }

            UnityEngine.Debug.Log(stackString);

            return true;
        }
    }
}
