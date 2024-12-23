using IchorsFringe.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace IchorsFringe.Content.Items
{
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class TrueIchorsFringe : ModItem
		//True Nights Edge is 35 Damage higher in Calamity.
	{
		public override void SetDefaults()
		{
			if (ModLoader.TryGetMod("CalamityMod", out Mod cal))
			{
				Item.damage = 122;
				Item.DamageType = DamageClass.Melee;
				Item.width = 140;
				Item.height = 140;
				Item.useTime = 42;
				Item.useAnimation = 42;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.knockBack = 8;
				Item.shoot = ModContent.ProjectileType<TrueIchorTooth>();
				Item.shootSpeed = 10;
				Item.noMelee = false;
				Item.value = Item.buyPrice(gold: 10);
				Item.rare = ItemRarityID.Yellow;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;
			}
			else
			{
                Item.damage = 82;
                Item.DamageType = DamageClass.Melee;
                Item.width = 140;
                Item.height = 140;
                Item.useTime = 42;
                Item.useAnimation = 42;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 8;
                Item.shoot = ModContent.ProjectileType<TrueIchorTooth>();
                Item.shootSpeed = 10;
                Item.noMelee = false;
                Item.value = Item.buyPrice(gold: 10);
                Item.rare = ItemRarityID.Yellow;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = true;
            }
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Content.Items.IchorsFringe>(), 1);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 3; // The number of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<TrueIchorTooth>(), Item.damage /2, Item.knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
