public class ShopItemCostTextViewModel : TextViewModel<ShopMenuModel>
{
    protected override string GetText()
    {
        var amount = Model.GetCurrentItemCost();
        if (amount == 0)
        {
            return string.Empty;
        }
        else
        {
            return $"{amount} / {Model.GetCurrentBoneBalance()} Bones";
        }
    }
}
