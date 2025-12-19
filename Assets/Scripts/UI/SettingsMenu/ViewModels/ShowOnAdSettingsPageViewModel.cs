public class ShowOnAdSettingsPageViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.CurrentPage == SettingsPage.Ads;
    }
}
