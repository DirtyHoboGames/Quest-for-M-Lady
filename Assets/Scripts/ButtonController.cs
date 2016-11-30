using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool pressed;

    public void OnPointerDown(PointerEventData eventData) {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData2) {
        pressed = false;
    }

    public bool GetPressed() {
        return pressed;
    }
}