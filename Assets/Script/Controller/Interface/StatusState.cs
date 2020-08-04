using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new state", menuName = "State Status")]
public class StatusState : ScriptableObject
{
    public enum StateType
    {
        HEAL, POISONED, CURSED
    }
   
    /// <summary>
    /// Durrée en seconde de l'effet (-1 si infini)
    /// </summary>
    [Header("Info")]
    public float time;
    public StateType type;
    public float value;
    public bool cummulable
    {
        get { return type != StateType.CURSED; }
    }

}
