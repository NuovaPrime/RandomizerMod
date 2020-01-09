using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomizerMod
{
    public class RandomizerModItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            if (ModContent.GetInstance<RandomizerModConfig>().NameRandomization)
            {
                string name1 = Lang.GetItemNameValue(Main.rand.Next(ItemLoader.ItemCount));
                if (name1.Contains(' '))
                {
                    string[] splitName = name1.Split(' ');
                    if (Main.rand.Next(2) == 0)
                        name1 = splitName.First();
                    else
                        name1 = splitName.Last();
                }
                string name2 = Lang.GetItemNameValue(Main.rand.Next(ItemLoader.ItemCount));
                if (name2.Contains(' '))
                {
                    string[] splitName = name2.Split(' ');
                    if (Main.rand.Next(2) == 0)
                        name2 = splitName.First();
                    else
                        name2 = splitName.Last();
                }
                if (Main.rand.Next(2) == 0)
                    item.SetNameOverride(name1 + " " + name2);
                else
                {
                    string name3 = Lang.GetItemNameValue(Main.rand.Next(ItemLoader.ItemCount));
                    if (name3.Contains(' '))
                    {
                        string[] splitName = name3.Split(' ');
                        if (Main.rand.Next(2) == 0)
                            name3 = splitName.First();
                        else
                            name3 = splitName.Last();
                    }
                    item.SetNameOverride(name1 + " " + name2 + " " + name3);
                }
                
            }
            if (ModContent.GetInstance<RandomizerModConfig>().StatsRandomization)
            {
                if (item.damage > 1)
                {
                    item.damage = Main.rand.Next(10, 60) + (Main.rand.Next(2) == 0 ? (Main.rand.Next(20, 100) + (Main.rand.Next(2) == 0 ? Main.rand.Next(40, 200) : 0)) : 0);
                    item.shoot = Main.rand.Next(ProjectileLoader.ProjectileCount);
                    item.knockBack = Main.rand.Next(10, 60) + (Main.rand.Next(2) == 0 ? (Main.rand.Next(20, 100) + (Main.rand.Next(2) == 0 ? Main.rand.Next(40, 200) : 0)) : 0);
                    item.useTime = Main.rand.Next(2, 500);
                    item.crit = Main.rand.Next(0, 100);
                }
            }
            if (ModContent.GetInstance<RandomizerModConfig>().ItemSpritesRandomization)
            {
                Main.itemTexture[item.type] = Main.itemTexture[Main.rand.Next(ItemLoader.ItemCount)];
            }
            if (ModContent.GetInstance<RandomizerModConfig>().SoundsRandomization)
            {
                item.UseSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Item, "Item" + Main.rand.Next(SoundLoader.SoundCount(Terraria.ModLoader.SoundType.Item)));
            }
        }
    }
}
