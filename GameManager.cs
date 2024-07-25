using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void MakeBottomObj()
    {
        GameObject bottomObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //bottom.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.5f, 1);
        bottomObj.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.5f, 1);
        bottomObj.transform.parent = transform;
        bottomObj.transform.localScale = new Vector3(10, 1, 1);
        bottomObj.transform.position = new Vector3(0, 0, -Camera.main.orthographicSize - 1.5f);
        bottomObj.layer = LayerMask.NameToLayer("Wall");
        bottomObj.name = "BottomObj";
        bottomObj.tag = "Wall";
        bottomObj.AddComponent<Collider>();
    }
    void MakeTopObj()
    {
        GameObject upper = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //bottom.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.5f, 1);
        upper.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.5f, 1);
        upper.transform.parent = transform;
        upper.transform.localScale = new Vector3(10, 1, 4);
        upper.transform.position = new Vector3(0, 0, 30 - Camera.main.orthographicSize - 1.5f + 2);
        upper.layer = LayerMask.NameToLayer("Wall");
        upper.name = "TopObj";
        upper.tag = "Wall";
        upper.AddComponent<Collider>();
    }
    void Start()
    {
        instance = this;
        enemies = new List<GameObject>();
        MakeBottomObj();
        MakeTopObj();

        
    }



    // Update is called once per frame
    public void OnEnemyAppear(GameObject obj)
    {
        enemies.Add(obj);
        PlayerController.instance.enemies = enemies;
    }
    public void OnEnemyDisAppear(GameObject obj)
    {
        enemies.Remove(obj);
        Destroy(obj);
        PlayerController.instance.enemies = enemies;
    }

}
