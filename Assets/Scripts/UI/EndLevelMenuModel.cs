public abstract class EndLevelMenuModel : Model
{
    protected SaveManager saveManager;

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

    private void Awake()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public virtual void ToLevelSelect()
    {
        saveManager.collectibleData.HASBALL = false;
        saveManager.Save();

        PauseUtility.Resume();
        Levels.Load(Levels.LevelSelect);
    }
}
