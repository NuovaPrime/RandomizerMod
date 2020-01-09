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
    public class RandomizerModProjectile : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            base.SetDefaults(projectile);

            if (ModContent.GetInstance<RandomizerModConfig>().ProjAIRandomization)
                projectile.aiStyle = Main.rand.Next(ProjectileLoader.ProjectileCount);

        }
    }
}
