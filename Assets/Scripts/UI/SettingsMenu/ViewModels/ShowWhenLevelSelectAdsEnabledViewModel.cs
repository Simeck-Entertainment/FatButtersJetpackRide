public class ShowWhenLevelSelectAdsEnabledViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.LevelSelectAdsEnabled;
    }
}
