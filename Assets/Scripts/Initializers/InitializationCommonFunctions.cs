using UnityEngine;
using UnityEngine.Networking;

public class InitializationCommonFunctions : MonoBehaviour
{
    [System.NonSerialized] public string remoteDir = "https://fatbutters.simeck.com/AssetBundles/";
    //public string AssetBundleDir = "/AssetBundles/";
    public bool updateComplete = false;
}

public class ForceAcceptAll : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

