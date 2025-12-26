using UnityEngine;

public class ShowWhenUIStateActiveViewModel : HideableViewModel<GameplayUIModel>
{
    [SerializeField] private GameplayUIState gameplayUIState;

    protected override bool IsVisible()
    {
        return Model.UIState == gameplayUIState;
    }
}
