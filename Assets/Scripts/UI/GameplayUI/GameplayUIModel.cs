using UnityEngine;

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
            Time.timeScale = 0.0f; // TODO Drake: Consider a global utility for pause and other game features like this
        }
        else
        {
            UIState = GameplayUIState.Base;
            Time.timeScale = 1.0f; // TODO Drake: Consider a global utility for resume
        }
    }
}
