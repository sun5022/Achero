using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    
    public Text[] texts;
    public Image[] images;
    public Sprite[] sprites;
    public static SkillManager instance;
    int totalNum;
    public int[] skillArr;
    void Start()
    {
        instance= this;
        RandomizeSkill();
    }

    public void RandomizeSkill(){
        totalNum = (int)SkillType.MAX_NUM;
        skillArr = new int[totalNum];
        for(int i = 0; i<totalNum ; i++){
            skillArr[i] = i;
        }
        for(int i = 0; i<100; i++){
            int a = Random.Range(0, totalNum);
            int b = Random.Range(0, totalNum);
            int temp = skillArr[a];
            skillArr[a] = skillArr[b];
            skillArr[b] = temp;
        }
        for(int i = 0; i<3; i++){
            //print(skillArr[i]);
            texts[i].text = Skill.skillNames[skillArr[i]] ;
            images[i].sprite = sprites[skillArr[i]];
        }
    }
    public void SelectSkill(int i){
        print("SelectSkill" + i);
        GameManager.instance.player.SetSkill((SkillType)skillArr[i], true);
        Skill skill = GameManager.instance.player.GetSkill((SkillType)skillArr[i]);
        print(skill);
        GameManager.instance.GameStart();
    }

}
