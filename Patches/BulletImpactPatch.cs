using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using TheShitMod.Components;
using UnityEngine;
using Photon.Pun;

namespace TheShitMod.Patches
{
    [HarmonyPatch(typeof(ProjectileHit))]
    [HarmonyPatch(nameof(ProjectileHit.RPCA_DoHit))]
    class BulletImpactPatch
    {
        static void Postfix(ProjectileHit __instance, ref Vector2 hitPoint, ref Vector2 hitNormal, ref Vector2 vel, ref int viewID, ref int colliderID, ref bool wasBlocked)
        {
            Collider2D collider;
            if (viewID != -1)
            {
                PhotonView photonView = PhotonNetwork.GetPhotonView(viewID);
                collider = photonView.GetComponentInChildren<Collider2D>();
            }
            else if (colliderID != -1)
            {
                collider = MapManager.instance.currentMap.Map.GetComponentsInChildren<Collider2D>()[colliderID];
            }
            else
            {
                UnityEngine.Debug.LogWarning("could not find collider!!!!!!! fuuuuuck");
                return;
            }

            float scaleChange = 1f;
            
            if (__instance.ownPlayer.gameObject.GetComponent<HasShrinkRayComponent>() != null)
            {
                UnityEngine.Debug.Log("shrink");
                scaleChange /= 2f;
            }
            else if (__instance.ownPlayer.gameObject.GetComponent<HasGrowthRayComponent>() != null)
            {
                UnityEngine.Debug.Log("grow");
                scaleChange *= 2f;
            }

            if (scaleChange != 1f)
            {
                var component = collider.gameObject.AddComponent<TempSizeChangeComponent>();
                component.m_scaleChange = scaleChange;
            }
        }
    }
}
