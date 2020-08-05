using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : AbstractController
{
    [Range(0,100)]
    public float life = 100;
    public override void Hit(float damage)
    {
        life -= damage;
        if (life <= 0) Destroy(gameObject);
    }
}
