using UnityEngine;
using UnityEngine.UI;

public abstract class SliderViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] protected Slider Slider;

    protected override void Awake()
    {
        base.Awake();
        if (Slider == null)
        {
            Slider = GetComponent<Slider>();
            if (Slider == null)
            {
                Debug.LogError($"{name} unable to find a Slider on this game object");
            }
        }

        Slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnDestroy()
    {
        Slider.onValueChanged.RemoveListener(OnSliderChanged);
    }

    protected override void OnModelChanged()
    {
        Slider.enabled = IsEnabled();
    }

    protected virtual bool IsEnabled()
    {
        return true;
    }

    protected abstract void OnSliderChanged(float value);
}
