using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace IchorsFringe.ModLoaderSettings.Utilities
{
    internal class Class1 : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasIngredient(ItemID.BloodButcherer) && recipe.HasTile(TileID.DemonAltar) && recipe.HasResult(ItemID.NightsEdge))
                {
                    recipe.DisableRecipe();
                }
            }
        }
    }
}


