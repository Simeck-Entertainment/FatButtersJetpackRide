public class ResumeButtonViewModel : ButtonViewModel<SettingsMenuModel>
{
    protected override void OnClick()
    {
        Model.ResumeGame();
    }
}
