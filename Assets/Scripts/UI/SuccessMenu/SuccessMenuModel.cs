public class SuccessMenuModel : EndLevelMenuModel
{
    public override void ToLevelSelect()
    {
        collectibleData.BONES = collectibleData.BONES + NewBones;
        collectibleData.LevelBeaten[SaveManager.Instance.sceneLoadData.LastLoadedLevelInt] = true;
        
        base.ToLevelSelect();
    }
}
