public class ShowTreatsButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    protected override void OnClick()
    {
        Model.TreatsVisible = !Model.TreatsVisible;
    }
}
