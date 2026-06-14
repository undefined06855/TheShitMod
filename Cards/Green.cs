using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheShitMod.Components;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TheShitMod.Cards
{
    class Green : CustomCard
    {
        protected override CardThemeColor.CardThemeColorType GetTheme() { return CardThemeColor.CardThemeColorType.PoisonGreen; }
        public override string GetModName() { return TheShitMod.ModInitials; }
        protected override CardInfo.Rarity GetRarity() { return CardInfo.Rarity.Common; }
        protected override GameObject GetCardArt() { return null; }

        // this member will only exist for some players but not others
        // i hope Photon likes this
        private GameObject? m_postProcessingObj;

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;

            statModifiers.health = 2f;
            statModifiers.lifeSteal = 1f;
            statModifiers.regen = 10f;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.AddComponent<GreenComponent>();

            if (player.GetComponent<GeneralInput>().controlledElseWhere) return;

            m_postProcessingObj = new GameObject { layer = 8 }; // 8: Default Post (from discord)

            var effect = m_postProcessingObj.AddComponent<PostProcessVolume>();
            effect.isGlobal = true;
            effect.priority = 999f;
            effect.weight = 1f;

            var profile = ScriptableObject.CreateInstance<PostProcessProfile>();

            var grading = profile.AddSettings<ColorGrading>();
            grading.colorFilter.Override(new Color(0.6f, 1f, 0.6f));
            grading.enabled.Override(true);

            effect.profile = profile;
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<GeneralInput>().controlledElseWhere) return;

            UnityEngine.Object.Destroy(player.gameObject.GetComponent<GreenComponent>()!);
            UnityEngine.Object.Destroy(m_postProcessingObj!);
        }

        protected override string GetTitle()
        {
            return "The Green";
        }

        protected override string GetDescription()
        {
            return "why are you green\nshhh it's okay\n\nalso you get health i guess";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Green",
                    amount = "Yes",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Limbs",
                    amount = "Lost ????",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
    }
}
