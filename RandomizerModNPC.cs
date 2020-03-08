using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomizerMod
{
    public class RandomizerModNPC : GlobalNPC
    {
        internal static List<int> ImportantNPCs = new List<int>() { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex, NPCID.CultistArcherBlue, NPCID.CultistDevote, NPCID.CultistTablet, NPCID.VoodooDemon, NPCID.DD2EterniaCrystal, NPCID.DD2LanePortal };
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
            if (ModContent.GetInstance<RandomizerModConfig>().NPCNameRandomization)
            {
                string name1 = Lang.GetNPCNameValue(Main.rand.Next(NPCLoader.NPCCount));
                if (name1.Contains(' '))
                {
                    string[] splitName = name1.Split(' ');
                    if (Main.rand.Next(2) == 0)
                        name1 = splitName.First();
                    else
                        name1 = splitName.Last();
                }
                string name2 = Lang.GetNPCNameValue(Main.rand.Next(NPCLoader.NPCCount));
                if (name2.Contains(' '))
                {
                    string[] splitName = name2.Split(' ');
                    if (Main.rand.Next(2) == 0)
                        name2 = splitName.First();
                    else
                        name2 = splitName.Last();
                }
                if (Main.rand.Next(2) == 0)
                    npc.GivenName = name1 + " " + name2;
                else
                {
                    string name3 = Lang.GetNPCNameValue(Main.rand.Next(NPCLoader.NPCCount));
                    if (name3.Contains(' '))
                    {
                        string[] splitName = name3.Split(' ');
                        if (Main.rand.Next(2) == 0)
                            name3 = splitName.First();
                        else
                            name3 = splitName.Last();
                    }
                    npc.GivenName = name1 + " " + name2 + " " + name3;
                }

            }
            if (ImportantNPCs.Contains(npc.type))
            {
                if (ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.affectsImportants)
                {
                    npc.aiStyle = Main.rand.Next(Main.npc.Length);
                }
            }
            if (npc.boss)
            {
                if (ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.affectsBosses)
                {
                    npc.aiStyle = Main.rand.Next(Main.npc.Length);
                }
            }
            if (ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.enabled)
            {
                //gross code incoming
                string forcedAI = ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.MemeAIRandomizationSettings.ForcedAI;
                if (forcedAI != "None")
                {
                    if (forcedAI == "Goldfish")
                        npc.aiStyle = 16;
                    else if (forcedAI == "Spiky Ball")
                        npc.aiStyle = 20;
                    //else if (forcedAI == "Pumpking")
                        //npc.aiStyle = 59;
                    else if (forcedAI == "Fishron")
                        npc.aiStyle = 69;
                    else if (forcedAI == "Bird")
                        npc.aiStyle = 24;
                }
                else if (!npc.boss && !ImportantNPCs.Contains(npc.type))
                    npc.aiStyle = Main.rand.Next(Main.npc.Length);
            }
            if (ModContent.GetInstance<RandomizerModConfig>().SoundsRandomization)
            {
                npc.HitSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.NPCHit, "NPCHit" + Main.rand.Next(SoundLoader.SoundCount(Terraria.ModLoader.SoundType.NPCHit)));
                npc.DeathSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.NPCKilled, "NPCDeath" + Main.rand.Next(SoundLoader.SoundCount(Terraria.ModLoader.SoundType.NPCKilled)));
            }
            if (ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.MemeAIRandomizationSettings.RandomSize)
            {
                npc.scale = Main.rand.NextFloat(0.1f, 3f);
            }
        }
        
        public void RandomiseShops(Chest shop, ref int nextSlot)
        {
            int numberitems = Main.rand.Next(1, 40);
            List<int> itemlist = new List<int>();
            int[] itemarray;
            Item item = new Item();
            for (int i = 0; i < ItemLoader.ItemCount; i++)
            {
                item.SetDefaults(i);
                if (item.type != 0)
                {
                    itemlist.Add(i);
                }
            }
            itemarray = itemlist.ToArray();
            for (int i = 0; i < numberitems; i++)
            {
                shop.item[nextSlot].SetDefaults(Main.rand.Next(itemarray));
                shop.item[nextSlot].value = Main.rand.Next(1, 1000000);
                nextSlot++;
            }
        }
        
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (ModContent.GetInstance<RandomizerModConfig>().NPCShopRandomization)
            {
                for (int i = 0; i < 40; i++)
                {
                    shop.item[i].TurnToAir();
                }
                nextSlot = 0;
                RandomiseShops(shop, ref nextSlot);
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (ModContent.GetInstance<RandomizerModConfig>().NPCLootRandomization.enabled)
            {
                if (ModContent.GetInstance<RandomizerModConfig>().NPCLootRandomization.bossesOnly)
                {
                    if (npc.boss)
                    {
                        Item.NewItem(npc.position, Main.rand.Next(ItemLoader.ItemCount));
                    }
                }
                else
                {
                    Item.NewItem(npc.position, Main.rand.Next(ItemLoader.ItemCount));
                }            
            }
            base.NPCLoot(npc);
        }

        public override void PostAI(NPC npc)
        {
            base.PostAI(npc);
            if (ModContent.GetInstance<RandomizerModConfig>().AIRandomizationSettings.overridesImmortality)
            {
                if (npc.immortal || npc.dontTakeDamage || npc.dontTakeDamageFromHostiles)
                {
                    npc.immortal = false;
                    npc.dontTakeDamage = false;
                    npc.dontTakeDamageFromHostiles = false;
                }
            }
        }
    }
}
