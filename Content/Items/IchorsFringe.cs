using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Intrinsics.X86;
using IchorsFringe.Content.Projectiles.Weapons;

namespace IchorsFringe.Content.Items
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class IchorsFringe : ModItem
        //nights edge is 5 damage higher in calamity.
    {
        public override void SetDefaults()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod cal))
            {
                Item.damage = 62;
                Item.DamageType = DamageClass.Melee;
                Item.width = 125;
                Item.height = 125;
                Item.useTime = 35;
                Item.useAnimation = 35;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 6;
                Item.value = Item.buyPrice(gold: 4);
                Item.rare = ItemRarityID.Orange;
                Item.UseSound = SoundID.Item1;
                Item.shoot = ModContent.ProjectileType<IchorTooth>();
                Item.shootSpeed = 10;
                Item.noMelee = false; // This is set the sword itself doesn't deal damage (only the projectile does).
                Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
                Item.autoReuse = true;
            }
            else
            {
                Item.damage = 52;
                Item.DamageType = DamageClass.Melee;
                Item.width = 125;
                Item.height = 125;
                Item.useTime = 35;
                Item.useAnimation = 35;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 6;
                Item.value = Item.buyPrice(gold: 4);
                Item.rare = ItemRarityID.Orange;
                Item.UseSound = SoundID.Item1;
                Item.shoot = ModContent.ProjectileType<IchorTooth>();
                Item.shootSpeed = 10;
                Item.noMelee = false; // This is set the sword itself doesn't deal damage (only the projectile does).
                Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
                Item.autoReuse = true;
            }
            
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CrimtaneWeapons);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.BloodButcherer, 540);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddIngredient(ItemID.BloodButcherer, 1);
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(ItemID.BladeofGrass, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
