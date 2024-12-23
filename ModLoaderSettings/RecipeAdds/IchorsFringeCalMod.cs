using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using IchorsFringe.Content.Items;

namespace IchorsFringe.ModLoaderSettings.RecipeAdds
{
    internal class IchorsFringeCalMod : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (ModLoader.TryGetMod("CalamityMod", out Mod cal) && recipe.HasIngredient(ItemID.BloodButcherer) && recipe.HasTile(TileID.DemonAltar) && recipe.HasResult(ModContent.ItemType<Content.Items.IchorsFringe>()))
                {
                    recipe.AddIngredient(ModContent.Find<ModItem>("CalamityMod", "PurifiedGel").Type, 5);
                }


            }
        }
    }
}
