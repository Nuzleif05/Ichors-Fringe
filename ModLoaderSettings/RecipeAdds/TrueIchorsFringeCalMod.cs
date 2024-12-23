using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.IO;
using Terraria;
using Terraria.ModLoader;
using IchorsFringe.Content.Items;

namespace IchorsFringe.ModLoaderSettings.RecipeAdds
{
    internal class TrueIchorsFringeCalMod : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (ModLoader.TryGetMod("CalamityMod", out Mod cal) && recipe.HasIngredient(ItemID.SoulofMight) && recipe.HasTile(TileID.MythrilAnvil) && recipe.HasResult(ModContent.ItemType<Content.Items.TrueIchorsFringe>()))
                {
                    recipe.RemoveIngredient(ItemID.SoulofMight);
                    recipe.RemoveIngredient(ItemID.SoulofSight);
                    recipe.RemoveIngredient(ItemID.SoulofFright);
                    recipe.AddIngredient(ItemID.SoulofMight, 3);
                    recipe.AddIngredient(ItemID.SoulofSight, 3);
                    recipe.AddIngredient(ItemID.SoulofFright, 3);
                }


            }
        
        }
    }
}
