using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public abstract class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string gameID = "5053457";
    [SerializeField] string adToShow = "Rewarded_Android";

    protected void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, true);
    }

    public virtual void PlayAd()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(adToShow);
    }

    public virtual void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads Ready");
    }

    public virtual void OnUnityAdsDidError(string message)
    {
    }

    public virtual void OnUnityAdsDidStart(string placementId)
    {
    }

    public virtual void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android")
        {
            if(ShowResult.Finished == showResult)
            {
                Debug.Log("Te doy la recompensa");
            }
            else
            {
                Debug.Log("Dudo, no te doy nada");
            }
        }
    }
}
