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
    class SwapHands : CustomCard
    {
        protected override CardThemeColor.CardThemeColorType GetTheme() { return CardThemeColor.CardThemeColorType.TechWhite; }
        public override string GetModName() { return TheShitMod.ModInitials; }
        protected override CardInfo.Rarity GetRarity() { return CardInfo.Rarity.Rare; }
        protected override GameObject GetCardArt() { return null; }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // check DealDamagePatch
            player.gameObject.AddComponent<IsSwappingHandsComponent>();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Object.Destroy(player.gameObject.GetComponent<IsSwappingHandsComponent>()!);
        }

        protected override string GetTitle()
        {
            return "Swap Hands";
        }

        protected override string GetDescription()
        {
            return "so you know like that uno\ncard nobody uses? this is it";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Swap",
                    amount = "On Hit",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }

    }
}
