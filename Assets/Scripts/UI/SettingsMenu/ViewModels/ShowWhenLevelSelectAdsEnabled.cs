public class ShowWhenLevelSelectAdsEnabled : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.LevelSelectAdsEnabled;
    }
}
