using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSheet;
using State;
using UnityEngine.PlayerLoop;

public class Controller : AbstractController
{
    public InputManager inputs;
    public Interface model;
    
    public float speedMultiplicator{get=>model.GetSpeed();}

    protected override void Awake()
    {
        base.Awake();
        model.Init(transform);
        state = new Iddle(this);
    }

    void Update()
    {
        state.Update();
    }
    
    public void Charge(int input)
    {
        state.ChargeState(model.GetWeapon(input));
    }
    public void Attack(int input)
    {
        state.AttackState(model.GetWeapon(input));
    }

    public void Skill(int input)
    {
        state.SkillState(model.GetSkill(input));
    }
    public void Release(int input)
    {
        state.ReleaseState();
    }
    public float GetSpeed()
    {
        return speedMultiplicator * speed;
    }

    public override void Hit(Controller origin, float damage)
    {
        model.AddDamage(damage);
    }
    
}
