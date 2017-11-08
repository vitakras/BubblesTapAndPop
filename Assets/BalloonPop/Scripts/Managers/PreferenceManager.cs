using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PreferenceManager : MonoBehaviour {

    public Score score;
    private BubblePrefs bubblePrefs; 

	// Use this for initialization
	void Start () {
        bubblePrefs = new BubblePrefs();
        Load();

        score.SetHighScore(bubblePrefs.highscore);
	}

    public void UpdateScore() {
        bubblePrefs.highscore = score.GetHighScore();
        Save();
    }

    void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/bubblePrefs.dat", FileMode.OpenOrCreate);

        bf.Serialize(file, bubblePrefs);
        file.Close();
    }

    void Load() {
        string filePath = Application.persistentDataPath + "/bubblePrefs.dat";
        if (File.Exists(filePath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            bubblePrefs = (BubblePrefs) bf.Deserialize(file);
            file.Close();
        }
    }
}
