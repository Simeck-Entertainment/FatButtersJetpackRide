using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using System.Collections;
public class Switch : MonoBehaviour
{
    public enum SwitchType
    {
        SingleFlip,
        Reversible,
        Timer
    }

    [SerializeField] private SwitchType switchType;

    private bool IsTimer => switchType == SwitchType.Timer;

    [SerializeField, ShowIf("IsTimer")] private float timer;

    [SerializeField] private UnityEvent onSwitchActivated;
    [SerializeField, ShowIf("IsTimer")] private UnityEvent onSwitchDeactivated;

    private bool isActivated;
    private Coroutine timerCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

    private void Interact()
    {
        switch (switchType)
        {
            case SwitchType.SingleFlip:
                if (!isActivated)
                {
                    Activate();
                }
                break;

            case SwitchType.Reversible:
                if (isActivated) Deactivate();
                else Activate();
                break;

            case SwitchType.Timer:
                if (isActivated)
                {
                    if (timerCoroutine != null) StopCoroutine(timerCoroutine);
                }
                else
                {
                    Activate();
                }
                timerCoroutine = StartCoroutine(TimerSequence());
                break;
        }
    }

    private void Activate()
    {
        isActivated = true;
        onSwitchActivated?.Invoke();
    }

    private void Deactivate()
    {
        isActivated = false;
        onSwitchDeactivated?.Invoke();
    }

    IEnumerator TimerSequence()
    {
        yield return new WaitForSeconds(timer);
        Deactivate();
        timerCoroutine = null;
    }

}