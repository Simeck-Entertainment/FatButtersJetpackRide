public class ShowOnBaseSettingsPageViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.CurrentPage == SettingsPage.Base;
    }
}
