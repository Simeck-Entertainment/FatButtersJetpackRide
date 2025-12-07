using Unity.Burst;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Please remember to turn off unused knobs")]

    [SerializeField] StartPos startPos;
    [SerializeField] PivotSide pivotSide;
    [SerializeField] OpenDir openDir;
    [SerializeField] Transform plusZPivot;
    [SerializeField] Transform minusZPivot;
    [SerializeField] float openCloseTime;
    [System.NonSerialized] bool activeUse;
    [System.NonSerialized] float counter;
    [System.NonSerialized] float goalRot;
    [System.NonSerialized] float timedOpenCloseStartRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeUse = false;   
        if(startPos == StartPos.closed)
        {
            instaClose();
        } else
        {
            instaOpen();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeUse)
        {
            RunOpenClose();
        }
    }


    public void Open()
    {
        timedOpenCloseStartRot = 0.0f;
        goalRot = 90.0f;
        ResetCounter();
    }

    public void Close()
    {
        timedOpenCloseStartRot = pickTransform().rotation.eulerAngles.y;
        goalRot = 0.0f;
        ResetCounter();

    }
    void ResetCounter()
    {
        counter = 0;
    }

    void instaClose()
    {
        plusZPivot.rotation = Quaternion.Euler(Vector3.zero);
        minusZPivot.rotation = Quaternion.Euler(Vector3.zero);
    }
    void instaOpen()
    {
        pickTransform().rotation = pickDirection();
    }

    private Quaternion pickDirection()
    {
        Quaternion pickedDirection;
        float minusZFixer;
        minusZFixer = (pivotSide == PivotSide.plusZ) ? 1.0f : -1.0f;
        if (openDir == OpenDir.plusX)
        {
            pickedDirection = Quaternion.Euler(Vector3.up * -90.0f * minusZFixer);
        }
        else
        {
            pickedDirection = Quaternion.Euler(Vector3.up * 90.0f * minusZFixer);
        }

        return pickedDirection;
    }

    private Transform pickTransform()
    {
        Transform pickedTransform;
        if (pivotSide == PivotSide.plusZ)
        {
            pickedTransform = plusZPivot;
        }
        else
        {
            pickedTransform = minusZPivot;
        }

        return pickedTransform;
    }

    void RunOpenClose()
    {
        counter += 1;
        if(counter > openCloseTime) //close us out if we're done.
        {
            activeUse = false;
            return;
        }
        float runPercent = counter / openCloseTime;
        float currentAngle = Vector3.Lerp(new Vector3(0.0f,timedOpenCloseStartRot,0.0f), new Vector3(0.0f,goalRot,0.0f), runPercent).y;
        pickTransform().rotation = Quaternion.Euler(new Vector3(0, currentAngle, 0));
        }
    enum PivotSide { plusZ, minusZ }
    enum OpenDir {plusX,minusX}
    enum StartPos {open,closed}
}
