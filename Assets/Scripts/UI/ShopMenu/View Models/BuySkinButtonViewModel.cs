public class BuySkinButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    protected override bool IsEnabled()
    {
        return !Model.IsActiveSkinOwned() && Model.GetCurrentBoneBalance() > Model.GetCurrentItemCost();
    }

    protected override void OnClick()
    {
        Model.BuyCurrentItem();
    }
}
