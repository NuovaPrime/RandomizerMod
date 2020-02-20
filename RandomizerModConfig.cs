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
        [ReloadRequired]
        public bool ItemNameRandomization { get; set; }

        [Label("NPC Name Randomization")]
        [Tooltip("Toggle the randomization of names for all npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NPCNameRandomization { get; set; }

        [Label("Weapon Stats Randomization")]
        [Tooltip("Toggle the randomization of stats for all Weapons.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool StatsRandomization { get; set; }

        [Label("Item Sprites Randomization")]
        [Tooltip("Toggle the randomization of sprites for all items.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ItemSpritesRandomization { get; set; }

        [Label("NPC & Item Sounds Randomization")]
        [Tooltip("Toggle the randomization of sounds for all items and npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool SoundsRandomization { get; set; }

        [Label("Projectile AI Randomization")]
        [Tooltip("Toggle the randomization of ai for all projectiles.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ProjAIRandomization { get; set; }
        
        [Label("Town NPC Shop Randomization")]
        [Tooltip("Toggle the randomization of shops for all npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NPCShopRandomization { get; set; }

        [Label("NPC Loot Randomization")]
        [Tooltip("Toggles the randomization of loot drops from enemies, they still drop their usual items though.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NPCLootRandomization { get; set; }

        [Header("[c/E61919:WARNING: Needs a beefy pc to use!]")]
        [Label("World Generation Randomization")]
        [Tooltip("Toggles the randomization of all tiles generated in a world.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool WorldGenRandomization { get; set; }

        [Label("Chest Contents Randomization")]
        [Tooltip("Toggle the randomization of items in all generated chests.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ChestsRandomization { get; set; }

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
        }
    }
}
