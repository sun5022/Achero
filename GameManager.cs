using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject skillPanel;
    public GameObject joystickPanel;
    public static GameManager instance;
    public List<GameObject> enemies;
    public Player player;
    // Start is called before the first frame update
    
    void SetSkillPanel(){
        skillPanel.SetActive(true);
        joystickPanel.SetActive(false);
        
    }
    void SetJojStickPanel(){
        skillPanel.SetActive(false);
        joystickPanel.SetActive(true);
    }
    public void GameStart(){
        SetJojStickPanel();
        
    }
    void Start()
    {
        instance = this;
        player = new Player(100, 2, 2);
        enemies = new List<GameObject>();
        MakeBottomObj();
        MakeTopObj();
        SetSkillPanel();


        
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

}
