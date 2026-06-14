using RarityLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShitMod.Components;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace TheShitMod.Cards
{
    class GrowthRay : CustomCard
    {
        protected override CardThemeColor.CardThemeColorType GetTheme() { return CardThemeColor.CardThemeColorType.EvilPurple; }
        public override string GetModName() { return TheShitMod.ModInitials; }
        protected override CardInfo.Rarity GetRarity() { return RarityUtils.GetRarity("Legendary"); }
        protected override GameObject GetCardArt() { return null; }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been setup.");
            cardInfo.allowMultiple = false;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            player.gameObject.AddComponent<HasGrowthRayComponent>();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");

            UnityEngine.Object.Destroy(player.gameObject.GetComponent<HasGrowthRayComponent>()!);
        }

        protected override string GetTitle()
        {
            return "Growth Ray";
        }

        protected override string GetDescription()
        {
            return "You get a laser gun with\nwhich you can increase the size of\nanything, including other\nbopls.";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Grow",
                    amount = "On Hit",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }

    }
}
