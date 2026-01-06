using UnityEngine;

public class ShopMenuModel : Model
{
    private bool _treatsVisible;
    public bool TreatsVisible
    {
        get
        {
            return _treatsVisible;
        }
        set
        {
            _treatsVisible = value;
            Refresh();
        }
    }

    public bool IsActiveSkinOwned()
    {
        return true;
    }
}
