using UnityEngine;

public class LevelSelectUIModel : Model
{
    [SerializeField] private LevelSelectScroller levelSelectScroller;

    // initialize the UI state to none so that LevelSelectAssetVisibilityManager can enable UI elements when ready
    private LevelSelectUIState _uiState = LevelSelectUIState.None;
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

    public float LevelSelectScrollValue
    {
        get
        {
            return levelSelectScroller.GetLeftRightScrollAmount();
        }
        set
        {
            levelSelectScroller.SetLeftRightScrollAmount(value);
            Refresh();
        }
    }

    public void GoToMainMenu()
    {
        Levels.Load(Levels.TitleScreen);
    }
}

public enum LevelSelectUIState
{
    None,
    Base,
    Settings,
    Shop
}