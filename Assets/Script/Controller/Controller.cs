using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSheet;
using State;
using UnityEngine.PlayerLoop;

public class Controller : AbstractController
{
    [Range(0,20)]
    public float speed = 8;
    public InputManager inputs;
    public Interface model;
    [HideInInspector] public Rigidbody rigidbody;
    public float speedMultiplicator{get=>model.GetSpeed();}

    public State.Abstract state;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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

    public void Release(int input)
    {
        state.ReleaseState();
    }
    public float GetSpeed()
    {
        return speedMultiplicator * speed;
    }

    public override void Hit(float damage)
    {
        model.AddDamage(damage);
    }
    
}
