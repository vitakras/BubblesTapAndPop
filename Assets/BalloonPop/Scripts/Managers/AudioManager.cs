using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer masterMixer;
    private bool soundOn;

    private static string volumeString = "Volume";

    void Start() {
            
    }

    public bool SoundOn {
        get {
            return soundOn;
        }

        set {
            soundOn = value;
            UpdateSound();
        }
    }

    public void UpdateSound() {
        if (soundOn) {
            masterMixer.ClearFloat(volumeString);
        } else {
            masterMixer.SetFloat(volumeString, -80f);
        }
    }
}
