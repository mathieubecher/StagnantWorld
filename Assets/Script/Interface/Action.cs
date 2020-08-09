using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Action : ScriptableObject
{
    /// <summary>
    /// Durée de l'attaque, -1 si infini
    /// </summary>
    //public float duration;
    protected float _time;
    public string animation;
    public float speed = 0;

    public bool rotate = false;
    
    // Comportement
    [HideInInspector] public Controller owner;
    
    protected virtual void OnCall(Controller controller,float time)
    {
        owner = controller;
        _time = time;
    }

    public virtual void Update()
    {
        
    }
    public virtual void OnExit()
    {
        owner.character.ReleaseAnimation();
    }
    public bool Time()
    {
        if (_time >= 0)
        {
            _time -= UnityEngine.Time.deltaTime;
            if (_time <= 0) return true;
        }
        return false;
    }
}
