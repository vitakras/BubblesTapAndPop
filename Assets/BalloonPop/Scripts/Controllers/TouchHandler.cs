using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour {

    public GameObject[] GetObjectsBeingTouched() {
        if (IsPointerOverUIObject()) {
            return new GameObject[0];
        }

        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.touches[i];
            if (touch.phase == TouchPhase.Began) {
                GameObject go = GetObjectBeingTouched(touch);

                if (go != null) {
                    goList.Add(go);
                }
            }
        }

        return goList.ToArray();
    }

    bool IsPointerOverUIObject() {
        if (EventSystem.current != null &&
            (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)) {
            return true;
        }

        return false;
    }

    GameObject GetObjectBeingTouched(Touch touch) {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.collider.gameObject;
        }

        return null;
    }
}
