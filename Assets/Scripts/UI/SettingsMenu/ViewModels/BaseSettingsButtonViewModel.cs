public class BaseSettingsButtonViewModel : ButtonViewModel<SettingsMenuModel>
{
    protected override void OnClick()
    {
        Model.CurrentPage = SettingsPage.Base;
    }
}