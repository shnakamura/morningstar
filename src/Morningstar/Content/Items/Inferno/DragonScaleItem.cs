namespace Morningstar.Content.Items.Inferno;

public class DragonScaleItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.width = 18;
        Item.height = 22;
        
        Item.rare = ItemRarityID.Blue;
            
        Item.value = Item.sellPrice(copper: 5);
    }
}