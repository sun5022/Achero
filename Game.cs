using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace Game
{
    public enum TouchState { IDLE, DOWN, DRAG, UP};
    public enum PlayerState { IDLE, ATTACK, HIT, RUN};
    public enum SkillType {DOUBLE_SHOT, PIERCE_SHOT, REFLECT_SHOT};

    [System.Serializable]
    public struct Skill{
        public SkillType type;
        public bool active;
        public Skill(SkillType type, bool active){
            this.type = type; this.active = active;
        }
        public override string ToString()
        {
            return "Skill=SkillType : " + type + " active : " + active;
        }

    }
    [System.Serializable]
    public struct Player{
        float hp;
        float speed;
        float attackSpeed;
        List<Skill> skills;
        
        public Player(float hp, float speed, float attackSpeed){
            this.hp = hp; this.speed = speed; this.attackSpeed = attackSpeed;
            skills = new List<Skill>();
            skills.Add(new Skill(SkillType.DOUBLE_SHOT, false));
            skills.Add(new Skill(SkillType.PIERCE_SHOT, false));
            skills.Add(new Skill(SkillType.REFLECT_SHOT, false));
            // for(int i = 0; i<skills.Count; i++){
            //     Debug.Log(skills[i]);
            // }
        }
        public override string ToString()
        {
            return "Player=hp : " + hp + " speed : " + attackSpeed;
        }
        public Skill GetSkill(SkillType type){
            return skills[(int)type];
        }
        public void SetSkill(SkillType type, bool active){
            Skill skill = new Skill(type, active);
            skills[(int)type] = skill;
        }


    }
}
