using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputHandler : MonoBehaviour, InputHandler {

    public GameObject[] GetObjectsBeingTouched() {
        List<GameObject> goList = new List<GameObject>();
        if (IsPointerOverUIObject()) {
            return goList.ToArray();
        }

        GameObject go = GetObjectBeingTouched();
        if (go != null) {
            Debug.Log("fsdf");
            goList.Add(go);
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

    GameObject GetObjectBeingTouched() {
        if (Input.GetButtonDown("Fire1")) {
            Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit.collider != null) {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
