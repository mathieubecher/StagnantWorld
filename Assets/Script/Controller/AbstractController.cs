using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{
    public Character character;

    void Awake()
    {
        character.controller = this;
    }

    public virtual void Hit(float damage)
    {
        
    }
}
