using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    public Transform playerTr;
    Vector3 offset;
    Vector3 pos1;
    Vector3 pos2;
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


        Vector3 p1 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 p2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        print("p1" + p1);
        print("p2" + p2);


    Ray ray = Camera.main.ScreenPointToRay(new Vector3(0, 0, 0));
    RaycastHit hit;
    BoxCollider box= GameObject.Find("World").GetComponent<BoxCollider>();
    print("box  " + box.name);
    pos1 = Vector3.zero;
    if(box.Raycast(ray, out hit, 1000))
    {
        pos1 = hit.point;
    }
    print("pos1" + pos1);


    Ray ray2 = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
    RaycastHit hit2;
    BoxCollider box2 = GameObject.Find("World").GetComponent<BoxCollider>();
    print("box  " + box2.name);
    pos2 = Vector3.zero;
    if (box2.Raycast(ray2, out hit2, 1000))
    {
        pos2 = hit2.point;
    }
    print("pos2" + pos2);


        offset = transform.position - playerTr.position;
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
    Vector3 cameraPos = Vector3.zero;
    void LateUpdate()
    {
        
        //if(playerTr.position + oth < oth)
        cameraPos.y = playerTr.position.y + offset.y;
        if (playerTr.position.z < 0)
        {
        }
        else if (playerTr.position.z + cam.orthographicSize * 2 > 30 + 1.5f)
        {
        }
        else
        {
            cameraPos.z = playerTr.position.z + offset.z;
            transform.position = cameraPos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}