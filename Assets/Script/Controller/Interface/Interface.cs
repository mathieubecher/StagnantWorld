using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interface", menuName = "Interface/Interface")]
public class Interface : ScriptableObject
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _statusPrefab;
    [SerializeField] private Statistics _statistics;
    
    private Status _status;

    /// <summary>
    /// Initialisation de l'interface
    /// </summary>
    /// <param name="parent"></param>
    public void Init(Transform parent)
    {
        _status = Instantiate((GameObject)Resources.Load("Status"), parent).GetComponent<Status>();
        _status.Init(_statistics);
    }

    #region Statistics
    /// <summary>
    /// Multiplicateur de vitesse actuel
    /// </summary>
    /// <returns></returns>
    public float GetSpeed()
    {
        return _statistics.normalSpeed;
    }
    
    #endregion
}
