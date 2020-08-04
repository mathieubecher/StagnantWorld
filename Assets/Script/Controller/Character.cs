using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector3 direction)
    {
        if (direction.magnitude > 0.1f) transform.LookAt(transform.position + direction);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("speed",speed);
    }
}
