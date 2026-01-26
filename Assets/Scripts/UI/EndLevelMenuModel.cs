public abstract class EndLevelMenuModel : Model
{
    protected CollectibleData collectibleData => SaveManager.Instance.collectibleData;

    private int _newBones;
    public int NewBones
    {
        get
        {
            return _newBones;
        }
        set
        {
            _newBones = value;
            Refresh();
        }
    }

    public virtual void ToLevelSelect()
    {
        collectibleData.HASBALL = false;
        SaveManager.Instance.Save();

        PauseUtility.Resume();
        Levels.Load(Levels.LevelSelect);
    }
}
