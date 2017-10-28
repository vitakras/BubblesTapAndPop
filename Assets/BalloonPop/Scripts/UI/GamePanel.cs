using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

    public Image activeColor;
    public ColorPicker colorPicker;

    public void UpdateActiveColor() {
        this.activeColor.color = colorPicker.ActiveColor;
    }

}
