public class GameplayUIModel : Model
{
    private SaveManager saveManager;

    private GameplayUIState _uiState;
    public GameplayUIState UIState
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

    public bool OnScreenControlsEnabled
    {
        get
        {
            // We'll refresh this each time we change UIState
            return saveManager.collectibleData.OnScreenControlsEnabled;
        }
    }

    public bool CorgiSenseEnabled
    {
        get
        {
            // We'll refresh this each time we change UIState
            return saveManager.collectibleData.CorgiSenseEnabled;
        }
    }

    private void Awake()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public void SetPaused(bool paused)
    {
        if (paused)
        {
            UIState = GameplayUIState.Settings;
            PauseUtility.Pause();
        }
        else
        {
            UIState = GameplayUIState.Base;
            PauseUtility.Resume();
        }
    }
}
