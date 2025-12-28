using UnityEngine;

public class SuccessMenuModel : EndLevelMenuModel
{
    public override void ToLevelSelect()
    {
        saveManager.collectibleData.BONES = saveManager.collectibleData.BONES + NewBones;
        saveManager.collectibleData.LevelBeaten[saveManager.sceneLoadData.LastLoadedLevelInt] = true;
        
        base.ToLevelSelect();
    }
}
