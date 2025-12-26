public class PrivacyPolicyButtonViewModel : ButtonViewModel<SettingsMenuModel>
{
    protected override void OnClick()
    {
        Model.ShowPrivacyPolicy();
    }
}
