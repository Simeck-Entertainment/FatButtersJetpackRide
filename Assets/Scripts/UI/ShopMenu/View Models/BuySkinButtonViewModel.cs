public class BuySkinButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    protected override bool IsEnabled()
    {
        return !Model.IsActiveSkinOwned();
    }

    protected override void OnClick()
    {
        Model.BuyCurrentSkin();
    }
}
