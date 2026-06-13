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
    class WashingMachineLicense : CustomCard
    {
        protected override CardThemeColor.CardThemeColorType GetTheme() { return CardThemeColor.CardThemeColorType.ColdBlue; }
        public override string GetModName() { return TheShitMod.ModInitials; }
        protected override CardInfo.Rarity GetRarity() { return CardInfo.Rarity.Common; }
        protected override GameObject GetCardArt() { return null; }

        private WashingMachineLicenseComponent? m_component;


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been setup.");
            cardInfo.allowMultiple = false;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");

            // check DealDamagePatch
            m_component = player.gameObject.AddComponent<WashingMachineLicenseComponent>();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{TheShitMod.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");

            UnityEngine.Object.Destroy(m_component!);
        }

        protected override string GetTitle()
        {
            return "Washing Machine License";
        }

        protected override string GetDescription()
        {
            return "LG F4X7011TBB 11kg Washing Machine - Black\nLOGIK L712WM23 7 kg 1200 Spin Washing Machine - White";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Washed",
                    amount = "Yes",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
    }
}
