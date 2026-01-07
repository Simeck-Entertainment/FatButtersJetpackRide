public class MainMenuButtonViewModel : ButtonViewModel<LevelSelectUIModel>
{
    protected override void OnClick()
    {
        Model.GoToMainMenu();
    }
}