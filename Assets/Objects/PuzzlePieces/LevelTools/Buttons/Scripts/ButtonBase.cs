using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Security;

public class ButtonBase : MonoBehaviour
{
    public enum ButtonType
    {
        Permanent,
        Temporary,
        Timed
    }

    [Header("Settings")]
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private float requiredWeight = 1f;
    [SerializeField] private bool isdebug;
    [SerializeField, ShowIf("IsTimed")] private float timer = 1f;

    [Header("Events")]
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onReleased;

    // Internal State
    private HashSet<Collider> collidersOnButton = new HashSet<Collider>();
    private float currentWeight;
    private bool isPressed;
    private Coroutine timerCoroutine;

    private bool IsTimed => buttonType == ButtonType.Timed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            printText($"Object Entered: {other.name}, Mass: {other.attachedRigidbody.mass}");
            collidersOnButton.Add(other);
            RecalculateWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidersOnButton.Contains(other))
        {
            printText($"Object Exited: {other.name}");
            collidersOnButton.Remove(other);
            RecalculateWeight();
        }
    }

    private void RecalculateWeight()
    {
        currentWeight = 0f;
        collidersOnButton.RemoveWhere(c => c == null);

        HashSet<Rigidbody> distinctBodies = new HashSet<Rigidbody>();

        foreach (var col in collidersOnButton)
        {
            if (col.attachedRigidbody != null)
            {
                distinctBodies.Add(col.attachedRigidbody);
            }
        }

        foreach (var rb in distinctBodies)
        {
            currentWeight += rb.mass;
        }

        printText($"Current Weight: {currentWeight} / Required: {requiredWeight}");

        CheckActivation();
    }

    private void CheckActivation()
    {
        bool weightMet = currentWeight >= requiredWeight;

        if (!isPressed && weightMet)
        {
            Press();
        }
        else if (isPressed && !weightMet && buttonType == ButtonType.Temporary)
        {
            Release();
        }
    }

    private void Press()
    {
        if (isPressed) return;
        printText("Pressed");
        isPressed = true;
        onPressed?.Invoke();

        if (buttonType == ButtonType.Timed)
        {
            if (timerCoroutine != null) StopCoroutine(timerCoroutine);
            timerCoroutine = StartCoroutine(ReleaseRoutine());
        }
    }

    private void Release()
    {
        if (!isPressed) return;
        printText("Released");
        isPressed = false;
        onReleased?.Invoke();
    }

    private System.Collections.IEnumerator ReleaseRoutine()
    {
        yield return new WaitForSeconds(timer);
        Release();
    }

    public void printText(string debugText)
    {
        if (isdebug) Debug.Log(debugText);
    }
}
