using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHandler : MonoBehaviour, InputHandler {

    public GameObject[] GetObjectsBeingTouched() {
        List<GameObject> goList = new List<GameObject>();
        if (IsPointerOverUIObject()) {
            return goList.ToArray();
        }

        GameObject go = GetObjectBeingTouched();
        if (go != null) {
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.collider.gameObject;
        }

        return null;
    }
}
