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

        [Label("NPC Ai Randomization")]
        [Tooltip("Toggle the randomization of ai for all npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool AIRandomization { get; set; }

        [Label("NPC & Item Name Randomization")]
        [Tooltip("Toggle the randomization of names for all items and npcs.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NameRandomization { get; set; }

        [Label("Item Stats Randomization")]
        [Tooltip("Toggle the randomization of stats for all items.")]
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

        [Label("Tile Texture Randomization")]
        [Tooltip("Toggle the randomization of textures for all tiles.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool TilesRandomization { get; set; }

        [Label("Chest Contents Randomization")]
        [Tooltip("Toggle the randomization of items in all generated chests.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ChestsRandomization { get; set; }
    }
}
