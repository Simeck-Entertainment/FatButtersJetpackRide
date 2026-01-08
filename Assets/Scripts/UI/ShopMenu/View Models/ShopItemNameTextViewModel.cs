public class ShopItemNameTextViewModel : TextViewModel<ShopMenuModel>
{
    protected override string GetText()
    {
        return Model.CurrentSelectedShopItem.itemName;
    }
}
