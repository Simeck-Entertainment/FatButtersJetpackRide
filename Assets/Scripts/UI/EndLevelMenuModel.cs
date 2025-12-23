using UnityEngine;

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

        Time.timeScale = 1.0f; // TODO Drake: Consider a global utility for pause and other game features like this
        Helper.LoadToLevel(Levels.LevelSelect);
    }
}
