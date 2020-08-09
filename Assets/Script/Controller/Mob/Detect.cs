using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class Detect : MonoBehaviour
{
    private SphereCollider collider;
    private List<AbstractController> detectZone;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    
    // Start is called before the first frame update
    void Awake()
    {
        detectZone = new List<AbstractController>();
        collider = GetComponent<SphereCollider>();
        collider.radius = radius;
    }

    public bool DetectNear(out AbstractController controller, AbstractController.Type owner)
    {
        controller = null; 
        bool find = false;
        detectZone.RemoveAll(ctx => ctx == null);
        
        foreach (var detect in detectZone)
        {
            if (detect.type != owner && Vector3.Angle(transform.rotation * Vector3.forward, detect.gameObject.transform.position - transform.position) < angle)
            {
                if (!find || (controller.transform.position - transform.position).magnitude >
                    (detect.transform.position - transform.position).magnitude)
                {
                    controller = detect;
                    find = true;
                }
            }
        }
        return find;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer == LayerMask.NameToLayer("Character") && other.gameObject.TryGetComponent(out Character detect))
        {
            detectZone.Add(detect.controller);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer == LayerMask.NameToLayer("Character") && other.gameObject.TryGetComponent(out Character detect))
        { 
            detectZone.Remove(detect.controller);
        }
    }
    
    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        float distance = 0.8f - Mathf.Min(0.8f,((Camera.current.transform.position - transform.position).magnitude - 20) / 30 * 0.8f);
        if (distance > 0) distance += 0.2f;
        Color c = Color.red;
        c.a = distance;

        UnityEditor.Handles.color = c;
        UnityEditor.Handles.DrawLine(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(transform.position.x, 0, transform.position.z) + Quaternion.Euler(new Vector3(0,angle,0)) * transform.rotation * Vector3.forward * radius);
        UnityEditor.Handles.DrawLine(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(transform.position.x, 0, transform.position.z) + Quaternion.Euler(new Vector3(0,-angle,0)) * transform.rotation * Vector3.forward * radius);
        UnityEditor.Handles.DrawWireArc(new Vector3(transform.position.x, 0, transform.position.z), Vector3.up, Quaternion.Euler(new Vector3(0,-angle,0)) * transform.rotation * Vector3.forward, angle * 2, radius);
        c.a = 0.05f * distance;
        UnityEditor.Handles.color = c;
        UnityEditor.Handles.DrawSolidArc(new Vector3(transform.position.x, 0, transform.position.z), Vector3.up, Quaternion.Euler(new Vector3(0,-angle,0)) * transform.rotation * Vector3.forward, angle * 2, radius);
    }
    #endif
}
