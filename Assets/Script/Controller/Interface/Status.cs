using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private Statistics statistics;
    private bool init;
    private float life {get => statistics.life; set => statistics.life = value; }
    private float maxLife {get => statistics.maxLife; set => statistics.maxLife = value; }
    private float speed {get => statistics.speed; set => statistics.speed = value; }
    private float maxSpeed {get => statistics.normalSpeed; set => statistics.normalSpeed = value; }

    // Effect
    private List<StatusState> states; 
    
    public void Init(Statistics status)
    {
        statistics = status;
        statistics.Init();
        states = new List<StatusState>();
        init = true;
    }

    void Update()
    {
        if (!init) return;
        foreach (var state in states)
        {
            switch (state.type)
            {
                case StatusState.StateType.HEAL :
                    life += state.value;
                    if (life > maxLife) life = maxLife;
                    break;
                case StatusState.StateType.POISONED :
                    AddDamage(state.value);
                    break;
            }
            if (state.time > 0)
            {
                state.time -= Time.deltaTime;
                if (state.time <= 0) states.Remove(state);
            }   
        }
    }
    
    /// <summary>
    /// Inflige des dégats au personnage
    /// </summary>
    /// <param name="damage">dégats reçus</param>
    /// <returns>Vérifie si le personnage est encore en vie</returns>
    public bool AddDamage(float damage)
    {
        life -= damage;
        return (life > 0);
    }
    
    /// <summary>
    /// Ajoute un état au personnage
    /// </summary>
    /// <param name="state">Etat appliqué au personnage</param>
    public void AddState(StatusState state)
    {
        if (!state.cummulable || !states.Exists(x => x.type == state.type))
        {
            states.Add(state);
        }
    }
}
