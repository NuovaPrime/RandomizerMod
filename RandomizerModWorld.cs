using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace RandomizerMod
{
    public class RandomizerModWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            if (ModContent.GetInstance<RandomizerModConfig>().WorldGenRandomization)
            {
                for (int x = 0; x < Main.maxTilesX; x++)
                {
                    for (int y = (int)Main.worldSurface / 16; y < Main.maxTilesY; y++)
                    {
                        if (WorldGen.InWorld(x, y))
                        {
                            ushort id = (ushort)Main.rand.Next(TileLoader.TileCount);
                            while (Main.tileFrameImportant[id] || id == TileID.GoldCoinPile || id == TileID.SilverCoinPile || id == TileID.CopperCoinPile || id == TileID.PlatinumCoinPile)
                            {
                                id = (ushort)Main.rand.Next(TileLoader.TileCount);
                            }
                            if (!Main.tileFrameImportant[id])
                            {
                                if (y > 40 && y < Main.maxTilesY - 40 && x > 40 && x < Main.maxTilesX - 40)
                                {
                                    if(!Main.tileFrameImportant[Main.tile[x, y].type])
                                    {
                                        WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(1, 8), WorldGen.genRand.Next(1, 8), id, false, 0f, 0f, false, true);
                                    }
                                }                        
                            }  
                        }
                    }
                }
            }
        }
    }
}
