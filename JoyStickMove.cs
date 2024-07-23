using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JoyStickMove : MonoBehaviour
{
    public static JoyStickMove instance;
    public Canvas canvas;
    public Image joystickBack;
    public Image stick;
    Vector2 firstDownPos;
    float backgroundRadius;
    float stickRadius;
    public Vector3 joyDir;
    Vector3 joystickPos;

    void Start()
    {
        instance = this;
        backgroundRadius = joystickBack.GetComponent<RectTransform>().sizeDelta.x/2 * canvas.scaleFactor;
        stickRadius = stick.GetComponent<RectTransform>().sizeDelta.x / 2 * canvas.scaleFactor;
        joyDir = Vector3.zero;
        //print("backgroundRadius" + backgroundRadius);
        joystickPos = joystickBack.transform.position;
    }

    public void PointerDown(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        //print("PointerDown" + pointerEventData.position);
        firstDownPos = pointerEventData.position;
        joystickBack.transform.position = firstDownPos;
        stick.transform.position = firstDownPos;

    }
    public void PointerDrag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        //print("PointerDrag" + pointerEventData.position);
        Vector2 dir = (pointerEventData.position - firstDownPos).normalized;
        joyDir = new Vector3(dir.x, 0, dir.y);
        float stickDistance = Vector3.Distance(pointerEventData.position, firstDownPos);
        if (stickDistance < backgroundRadius- stickRadius)
        {
            stick.transform.position = firstDownPos + dir * stickDistance;
        }
        else
        {
            stick.transform.position = firstDownPos + dir * (backgroundRadius- stickRadius);
        }

    }
    public void PointerUp(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        //print("PointerUp" + pointerEventData.position);
        joystickBack.transform.position = joystickPos;
        stick.transform.position = joystickPos;
        joyDir = Vector3.zero;
    }
}
