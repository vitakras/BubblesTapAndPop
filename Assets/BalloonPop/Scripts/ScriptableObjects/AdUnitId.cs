using UnityEngine;
using GoogleMobileAds.Api;

[CreateAssetMenu(fileName = "AdUnitId.asset", menuName = "AdUnitId", order = 1)]
public class AdUnitId : ScriptableObject {

    public string adUnitId;

    public BannerView GetBannerView() {
        return new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
    }
}
