using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSheet;

public class Controller : MonoBehaviour
{
    public InputManager inputs;
    public Character character;
    public Interface model;
    public float speedMultiplicator{get=>model.GetSpeed();}

    void Awake()
    {
        model.Init(transform);
    }
}
