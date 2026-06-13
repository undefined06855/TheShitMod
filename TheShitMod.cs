using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using TheShitMod.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


namespace TheShitMod
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]

    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class TheShitMod : BaseUnityPlugin
    {
        private const string ModId = "dev.undefined0.theshitmod";
        private const string ModName = "The Shit Mod";
        public const string Version = "1.0.0";
        public const string ModInitials = "SM";

        public static TheShitMod instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        void Start()
        {
            instance = this;
            CustomCard.BuildCard<SpeakToTheHand>();
            CustomCard.BuildCard<TheOnePercent>();
            CustomCard.BuildCard<Green>();
            CustomCard.BuildCard<FuckImFallingOver>();
            CustomCard.BuildCard<SwapHands>();
            CustomCard.BuildCard<Damager>();
            CustomCard.BuildCard<ThisIsOneBigMagazine>();
            CustomCard.BuildCard<WashingMachineLicense>();
        }
    }
}
