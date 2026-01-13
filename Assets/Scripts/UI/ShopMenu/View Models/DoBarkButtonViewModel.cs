using UnityEngine;

public class DoBarkButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    [SerializeField] private AudioClip[] barkClips;
    [SerializeField] private AudioSource audioSource;

    protected override void OnClick()
    {
        var thisBark = barkClips[Random.Range(0, barkClips.Length - 1)];

        audioSource.clip = thisBark;
        audioSource.Play();
    }
}
