namespace Morningstar.Content.Items.Inferno;

public class FishmotherItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults(); 
        
        Item.maxStack = Item.CommonMaxStack;

        Item.width = 34;
        Item.height = 34;

        Item.rare = ItemRarityID.Green;
    }
}