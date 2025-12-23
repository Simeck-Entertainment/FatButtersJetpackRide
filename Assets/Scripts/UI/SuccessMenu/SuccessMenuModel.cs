using UnityEngine;

public class SuccessMenuModel : Model
{
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
}
