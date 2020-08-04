using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Statistics", menuName = "Interface/Statistics")]
public class Statistics : ScriptableObject
{
    // Life
    [HideInInspector] public float life;
    
    public float maxLife;
    
    // Speed
    [HideInInspector] public float speed;
    [HideInInspector] public float normalSpeed = 1;

    public void Init()
    {
        life = maxLife;
        speed = normalSpeed;
    }
}
