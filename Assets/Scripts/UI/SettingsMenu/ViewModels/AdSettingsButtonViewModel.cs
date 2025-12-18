public class AdSettingsButtonViewModel : ButtonViewModel<SettingsMenuModel>
{
    protected override void OnClick()
    {
        Model.CurrentPage = SettingsPage.Ads;
    }
}
