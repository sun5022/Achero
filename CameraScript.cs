using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        float width;
        float height;
        float designRatio = 16.0f / 9;
        cam = Camera.main;
        float size = cam.orthographicSize;
        width = Screen.width;
        height = Screen.height;
        float targetRatio = height / width;
        // 16/9 : 2/1 = 50 : fov
        // fov = 2/1 * 50 / (16/9)
        float targetSize = targetRatio * size / designRatio;
        //print(targetfov);
        cam.orthographicSize = targetSize;
        
        /*
        float width;
        float height;
        float designRatio = 16.0f / 9;
        cam = Camera.main;
        float fov = cam.fieldOfView;
        width = Screen.width;
        height= Screen.height;
        float targetRatio = height/width;
        // 16/9 : 2/1 = 50 : fov
        // fov = 2/1 * 50 / (16/9)
        float targetfov = targetRatio * fov / designRatio;
        //print(targetfov);
        cam.fieldOfView = targetfov;
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
