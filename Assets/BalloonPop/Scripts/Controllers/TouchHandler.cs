using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, InputHandler {

    public GameObject[] GetObjectsBeingTouched() {
        List<GameObject> goList = new List<GameObject>();
        if (IsPointerOverUIObject()) {
            return goList.ToArray();
        }

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
        Vector2 origin = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
        if (hit.collider != null) {
            return hit.collider.gameObject;
        }

        return null;
    }
}
