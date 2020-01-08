using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RandomizerMod
{
    public class RandomizerModNPC : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
            if (ModContent.GetInstance<RandomizerModConfig>().NameRandomization)
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

            if (ModContent.GetInstance<RandomizerModConfig>().AIRandomization)
            {
                npc.aiStyle = Main.rand.Next(Main.npc.Length);
            }            
        }
    }
}
