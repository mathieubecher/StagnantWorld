using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSheet;

public class Controller : AbstractController
{
    public InputManager inputs;
    public Interface model;
    public float speedMultiplicator{get=>model.GetSpeed();}

    private Animator stateMachine;
    [HideInInspector] public State.Abstract state;
    
    void Awake()
    {
        stateMachine = GetComponent<Animator>();
        model.Init(transform);
    }
    
    public void Exit()
    {
        stateMachine.SetTrigger("Exit");
    }

    public void Attack(int index, float charge)
    {
        stateMachine.SetFloat("charge",charge);
        
        stateMachine.SetInteger("attackInput", index);
        if (!model.IsReleasable(index, charge))
        {
            if(state.GetType() == typeof(State.Charge)) ((State.Charge)state).Release();
            return;
        }
        stateMachine.SetTrigger("Attack");
    }
    public void Charge(int input)
    {
        if (model.IsChargable(input))
        {
            Debug.Log("charge");
            stateMachine.SetInteger("attackInput", input);
            stateMachine.SetTrigger("Charge");
        }
    }

    public override void Hit(float damage)
    {
        model.AddDamage(damage);
    }

}
