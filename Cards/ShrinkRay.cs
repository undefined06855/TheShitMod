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
    class ShrinkRay : CustomCard
    {
        protected override CardThemeColor.CardThemeColorType GetTheme() { return CardThemeColor.CardThemeColorType.EvilPurple; }
        public override string GetModName() { return TheShitMod.ModInitials; }
        protected override CardInfo.Rarity GetRarity() { return RarityUtils.GetRarity("Legendary"); }
        protected override GameObject GetCardArt() { return null; }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // check BulletImpactPatch
            player.gameObject.AddComponent<HasShrinkRayComponent>();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Object.Destroy(player.gameObject.GetComponent<HasShrinkRayComponent>()!);
        }

        protected override string GetTitle()
        {
            return "Shrink Ray";
        }

        protected override string GetDescription()
        {
            return "You get a laser gun with\nwhich you can decrease the size of\nanything, including other\nbopls.";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Shrink",
                    amount = "On Hit",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }

    }
}
