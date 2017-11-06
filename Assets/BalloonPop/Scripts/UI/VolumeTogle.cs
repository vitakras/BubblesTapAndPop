using UnityEngine;

public class VolumeTogle : MonoBehaviour {

    public AudioManager audioManager;
    public GameObject volumeOnButton;
    public GameObject volumeOffButton;

    void Awake() {
        if (audioManager.SoundOn) {
            volumeOffButton.SetActive(true);
            volumeOnButton.SetActive(false);
        } else {
            volumeOffButton.SetActive(false);
            volumeOnButton.SetActive(true);
        }
    }
}
