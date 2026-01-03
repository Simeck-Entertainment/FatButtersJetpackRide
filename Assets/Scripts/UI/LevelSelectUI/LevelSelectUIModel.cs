using UnityEngine;

public class LevelSelectUIModel : Model
{
    [SerializeField] private LevelSelectScroller levelSelectScroller;

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
    Base,
    Settings,
    Shop
}