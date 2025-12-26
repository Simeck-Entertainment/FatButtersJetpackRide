public class LevelSelectUIModel : Model
{
    private LevelSelectUIState _uiState;
    public LevelSelectUIState UIState
    {
        get
        {
            return _uiState;
        }
        set
        {
            _uiState = value;
            Refresh();
        }
    }
}

public enum LevelSelectUIState
{
    Base,
    Settings
}