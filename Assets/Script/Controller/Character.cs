using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator _animator;
    public WeaponView weapon1;
    public WeaponView weapon2;
    [HideInInspector] public AbstractController controller;
    
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
    
    public float SetAttackAnimation(string name)
    {
        _animator.Play(name);
        _animator.ResetTrigger("Release");
        
        //TODO Bug de gestion possible
        _animator.Update(Time.deltaTime);
        
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
       return (!state.loop)?state.length:-1;
    }

    public void ReleaseAnimation()
    {
        _animator.SetTrigger("Release");
    }

    public void SetWeaponCollider(Weapon weapon, bool enabled)
    {
        SetWeaponCollider((weapon == weapon1.weapon)?0:1, enabled);
    }
    public void SetWeaponCollider(int input, bool enabled)
    {
        if (input == 0) weapon1.collider.enabled = enabled;
        else weapon2.collider.enabled = enabled;
    }
}
