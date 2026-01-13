using UnityEngine;

public class BoneCounterModel : Model
{
    [Tooltip("Nullable, if there is no player it will just use the save data.")]
    [SerializeField] private Player player;

    private SaveManager saveManager;

    private int _boneCount;
    public int BoneCount
    {
        get
        {
            return _boneCount;
        }
        set
        {
            _boneCount = value;
            Refresh();
        }
    }

    private void Start()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>(); // TODO Drake: Singleton pattern for this?
        saveManager.Load();

        if (player != null)
        {
            player.OnBonesCollected.AddListener(OnBonesChanged);
        }

        saveManager.collectibleData.OnBonesChanged.AddListener(OnBonesChanged);

        OnBonesChanged();
    }

    private void OnBonesChanged()
    {
        BoneCount = saveManager.collectibleData.BONES + (player?.tempBones ?? 0);
    }
}
