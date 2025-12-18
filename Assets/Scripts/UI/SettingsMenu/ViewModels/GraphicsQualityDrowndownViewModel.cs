public class GraphicsQualityDrowndownViewModel : DropdownViewModel<SettingsMenuModel>
{
    protected override void OnDropdownChanged(int index)
    {
        Model.SetGraphicsSettings(index);
    }

    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Dropdown.value = Model.CollectibleData.GraphicsQualityLevel;
    }
}
