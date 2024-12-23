using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IchorsFringe.Content.Projectiles.Weapons;

namespace IchorsFringe.Content.Projectiles.Weapons
{
    public class TrueIchorTooth : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.arrow = false;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void AI()
        {
            if (Projectile.penetrate == 1)
            {
                Projectile.alpha = 255;
                Projectile.Resize(250, 250);
                Projectile.penetrate = -1;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, 4f, 1f, 1, default, 2f);
                SoundEngine.PlaySound(SoundID.Item167);
                SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
                Projectile.timeLeft = 30;



            }
        }



        // Additional hooks/methods here.
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // If collide with tile, reduce the penetrate.
            // So the projectile can reflect at most 5 times
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Item167, Projectile.position);

                // If the projectile hits the left or right side of the tile, reverse the X velocity
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }

                // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.BloodButcherer, 900);
            target.AddBuff(BuffID.Ichor, 900);
        }
    }
}