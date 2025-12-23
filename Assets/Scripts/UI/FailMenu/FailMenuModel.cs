using UnityEngine;

public class FailMenuModel : Model
{
    private FailReason _failReason;
    public FailReason FailReason
    {
        get
        {
            return _failReason;
        }
        set
        {
            _failReason = value;
            Refresh();
        }
    }
}

public enum FailReason
{
    NoHealth,
    NoFuel
}
