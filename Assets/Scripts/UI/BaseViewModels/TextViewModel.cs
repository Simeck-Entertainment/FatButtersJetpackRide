using UnityEngine;
using TMPro;

public abstract class TextViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] protected TMP_Text Text;

    protected override void Awake()
    {
        base.Awake();
        if (Text == null)
        {
            Text = GetComponent<TMP_Text>();
            if (Text == null)
            {
                Debug.LogError($"{name} unable to find a TMP_Text on this game object");
            }
        }
    }

    protected override void OnModelChanged()
    {
        Text.text = GetText();
    }

    protected abstract string GetText();
}
