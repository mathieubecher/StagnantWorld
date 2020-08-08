using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{
    public enum Type
    {
        AMICAL, HOSTIL
    }

    public string stateName;
    public State.Abstract state;

    public Type type;
    [HideInInspector] public Rigidbody rigidbody;
    public Character character;
    [Range(0,20)]
    public float speed = 8;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        character.controller = this;
    }

    public virtual void Hit(Controller origin, float damage)
    {
        
    }
}
