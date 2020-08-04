using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector3 move;
    
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        move = new Vector3(direction.x, 0, direction.y);
    }
    public void Attack1(InputAction.CallbackContext context)
    {
        if(context.started) Debug.Log("Attack 1");
    }

    public void Attack2(InputAction.CallbackContext context)
    {
        if(context.started) Debug.Log("Attack 2");
    }
}
