public class GraphicsQualityDrowndownViewModel : DropdownViewModel<SettingsMenuModel>
{
    protected override void OnDropdownChanged(int index)
    {
        Model.GraphicsQuality = index;
    }

    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Dropdown.value = Model.GraphicsQuality;
    }
}
