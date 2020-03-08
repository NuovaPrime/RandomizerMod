using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace RandomizerMod
{
    public class RandomizerModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("NPC AI Randomization Settings")]
        [Tooltip("Configure the randomization of ai for all npcs.")]
        public AIRandomizations AIRandomizationSettings = new AIRandomizations();

        [Label("Item Name Randomization")]
        [Tooltip("Toggle the randomization of names for all items.")]
        [DefaultValue(false)]
        public bool ItemNameRandomization { get; set; }

        [Label("NPC Name Randomization")]
        [Tooltip("Toggle the randomization of names for all npcs.")]
        [DefaultValue(false)]
        public bool NPCNameRandomization { get; set; }

        [Label("Weapon Stats Randomization")]
        [Tooltip("Toggle the randomization of stats for all Weapons.")]
        [DefaultValue(false)]
        public bool StatsRandomization { get; set; }

        [Label("Random Weapon Projectiles")]
        [Tooltip("Toggle the randomization of projectiles that each weapon fires.")]
        [DefaultValue(false)]
        public bool RandomProjRandomization { get; set; }

        [Label("Item Sprites Randomization")]
        [Tooltip("Toggle the randomization of sprites for all items.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ItemSpritesRandomization { get; set; }

        [Label("NPC & Item Sounds Randomization")]
        [Tooltip("Toggle the randomization of sounds for all items and npcs.")]
        [DefaultValue(false)]
        public bool SoundsRandomization { get; set; }

        [Label("Projectile AI Randomization")]
        [Tooltip("Toggle the randomization of ai for all projectiles.")]
        [DefaultValue(false)]
        public bool ProjAIRandomization { get; set; }
        
        [Label("Town NPC Shop Randomization")]
        [Tooltip("Toggle the randomization of shops for all npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NPCShopRandomization { get; set; }

        [Label("NPC Loot Randomization")]
        [Tooltip("Configure the randomization of extra drops from enemies.")]
        public NPCLootRandomizations NPCLootRandomization = new NPCLootRandomizations();

        [Label("Chest Contents Randomization")]
        [Tooltip("Toggle the randomization of items in all generated chests.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ChestsRandomization { get; set; }

        [Header("[c/E61919:WARNING: Needs a beefy pc to use!]")]
        [Label("World Generation Randomization")]
        [Tooltip("Toggles the randomization of all tiles generated in a world.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool WorldGenRandomization { get; set; }


        [SeparatePage]
        public class NPCLootRandomizations
        {
            [Label("All enemies drop random items?")]
            [DefaultValue(false)]
            public bool enabled = false;

            [Label("Only bosses drop random items?")]
            [DefaultValue(false)]
            public bool bossesOnly = false;
        }

        [SeparatePage]
        public class AIRandomizations
        {
            [Label("Randomization affects normal enemies?")]
            [DefaultValue(false)]
            public bool enabled = false;

            [Label("Randomization affects bosses?")]
            [DefaultValue(false)]
            public bool affectsBosses = false;

            [Label("Randomization affects progression-important enemies?")]
            [DefaultValue(false)]
            public bool affectsImportants = false;

            [Label("Override immortality on randomized enemies?")]
            [DefaultValue(false)]
            public bool overridesImmortality = false;

            [Label("Meme AI Settings")]
            [Tooltip("Choose from a few meme options for AI, you are welcome hectic.")]
            public MemeAIRandomizations MemeAIRandomizationSettings = new MemeAIRandomizations();
        }

        [SeparatePage]
        public class MemeAIRandomizations
        {
            [Label("AI Override")]
            [Tooltip("Choose from a list of specific AI's that all npc's will become.")]
            [DrawTicks]
            [OptionStrings(new string[] { "None", "Goldfish", "Spiky Ball", "Fishron", "Bird" })]
            [DefaultValue("None")]
            public string ForcedAI;

            [Label("Randomized Enemy Size")]
            [Tooltip("Randomize the size of all enemies between 0.1x and 3x")]
            public bool RandomSize = false;
        }
    }
}
