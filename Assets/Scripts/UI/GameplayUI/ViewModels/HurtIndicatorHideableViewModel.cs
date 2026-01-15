using UnityEngine;

public class HurtIndicatorHideableViewModel : HideableViewModel<GameplayUIModel>
{
    [SerializeField] private float showHurtDuration = 0.15f;

    private float currentHurtDuration = 0;

    protected override bool IsVisible()
    {
        return Model.IsRunningHurt;
    }

    private void FixedUpdate()
    {
        if (Model.IsRunningHurt)
        {
            currentHurtDuration += Time.deltaTime;
            if (currentHurtDuration >= showHurtDuration)
            {
                Model.IsRunningHurt = false;
                currentHurtDuration = 0;
            }
        }
    }
}
