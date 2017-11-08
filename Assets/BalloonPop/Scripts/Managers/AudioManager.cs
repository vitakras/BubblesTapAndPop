using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer masterMixer;
    private bool soundOn;

    private const string volumeString = "Volume";
    private const string soundString = "sound"; 

    void Start() {
        Load();
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

    void UpdateSound() {
        if (soundOn) {
            masterMixer.ClearFloat(volumeString);
        } else {
            masterMixer.SetFloat(volumeString, -80f);
        }

        Save();
    }

    void Save() {
        int value = 0;
        if (soundOn) {
            value = 1;
        }

        PlayerPrefs.SetInt(soundString, value);
    }

    void Load() {
        int value = PlayerPrefs.GetInt(soundString, 0);
        
        if (value == 1) {
            SoundOn = true;
        } else {
            SoundOn = false;
        }
    }
}
