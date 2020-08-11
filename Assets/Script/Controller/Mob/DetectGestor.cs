using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGestor : MonoBehaviour
{
    public List<Detect> detects;

    public float abandonRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DetectNear(out AbstractController controller, AbstractController.Type owner)
    {
        AbstractController target;
        controller = null;
        bool find = false;
        foreach (var detect in detects)
        {
            bool active = detect.DetectNear(out target, owner);
            
            if (active && !find) controller = target;
            else if (active && (target.transform.position - transform.position).magnitude < (controller.transform.position - transform.position).magnitude) controller = target;
            
            find |= active;
        }

        return find;
    }
    
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        float distance = 0.8f - Mathf.Min(0.8f,((Camera.current.transform.position - transform.position).magnitude - 20) / 30 * 0.8f);
        if (distance > 0) distance += 0.2f;
        Color c = Color.white;
        c.a = distance;
        
        UnityEditor.Handles.color = c;

        Vector3 center = transform.position;
        center.y = 0;
        UnityEditor.Handles.DrawWireDisc(center, Vector3.up, abandonRadius);
    }
#endif
}
