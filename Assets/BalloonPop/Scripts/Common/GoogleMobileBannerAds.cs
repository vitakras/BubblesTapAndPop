using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleMobileBannerAds : MonoBehaviour {

    public bool showOnLoad = true;
    public AdUnitId androidId;
    public AdUnitId iosId;

    private BannerView bannerView;

	// Use this for initialization
	void Start () {
        SelectAdUnitId();
        RequestBanner();

        if (showOnLoad) {
            Show();
        }
    }

    public void Show() {
        bannerView.Show();
    }

    public void Hide() {
        bannerView.Hide();
    }
    
    void RequestBanner() {
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    void SelectAdUnitId() {
#if UNITY_ANDROID
        bannerView = androidId.GetBannerView();
#elif UNITY_IPHONE
        bannerView = iosId.GetBannerView();
#endif
    }
}
