using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IchorsFringe.Content.Projectiles.Weapons
{
    public class IchorBoom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.arrow = false;
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.aiStyle = 117;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;
            Projectile.localNPCHitCooldown = -1;
            // AIType = ProjectileID.MolotovCocktail;
        } //SolarWhipSwordExplosion MiniNukeRocketI

        public override void AI()
        {

            // Loop through the 4 animation frames, spending 5 ticks on each
            // Projectile.frame — index of current frame
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;
                // Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            ++this.Projectile.ai[0];
            if ((double)this.Projectile.ai[0] <= 10.0)
                return;
            this.Projectile.Kill();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.width = 150;
            Projectile.height = 150;
            SoundEngine.PlaySound(SoundID.Item167, Projectile.position);

            //Projectile.position.X = Projectile.position.X + (Projectile.width / 2);
            //Projectile.position.Y = Projectile.position.Y + (Projectile.height / 2);


            for (int i = 0; i < 10; i++)
            {
                Vector2 dustPosition = Projectile.position;
                int dustIndex = Dust.NewDust(dustPosition, 1, 1, DustID.CrimtaneWeapons, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dustIndex].scale *= 1.75f;
            }
            target.AddBuff(BuffID.BloodButcherer, 540);
        }
        public virtual bool PreDraw(ref Color lightColor) => false;

    }
}

        // Additional hooks/methods here.