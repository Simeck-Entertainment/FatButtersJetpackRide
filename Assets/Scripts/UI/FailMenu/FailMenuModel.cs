public class FailMenuModel : EndLevelMenuModel
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

    public override void ToLevelSelect()
    {
        saveManager.collectibleData.BONES = saveManager.collectibleData.BONES + NewBones;
        
        base.ToLevelSelect();
    }
}

public enum FailReason
{
    NoHealth,
    NoFuel
}
