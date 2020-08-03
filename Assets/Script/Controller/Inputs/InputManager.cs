using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector3 move;
    
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
        Vector2 direction = context.ReadValue<Vector2>();
        move = new Vector3(direction.x, 0, direction.y);
    }
}
