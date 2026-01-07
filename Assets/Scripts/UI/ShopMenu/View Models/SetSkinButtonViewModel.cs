public class SetSkinButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    protected override bool IsEnabled()
    {
        return Model.IsActiveSkinOwned() && !Model.IsActiveSkinEquipped();
    }

    protected override void OnClick()
    {
        Model.EquipCurrentSkin();
    }
}
