using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler {

    public GameObjectEvent onGameObjectFoundEvent;

    void Start() {
        if (onGameObjectFoundEvent == null) {
            onGameObjectFoundEvent = new GameObjectEvent();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        GameObject go = FindTouched2DGameObject(eventData);
        if (go != null) {
            onGameObjectFoundEvent.Invoke(go);
        }
    }

    GameObject FindTouched2DGameObject(PointerEventData eventData) {
        Vector2 origin = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
        if (hit.collider != null) {
            return hit.collider.gameObject;
        }
        return null;
    }
}
