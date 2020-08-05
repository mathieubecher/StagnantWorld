using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector3 move;
    public Controller controller;

    public bool ischarge1;
    public bool ischarge2;
    public float charge1 = 0;
    public float charge2 = 0;

    void Update()
    {
        if (ischarge1 && charge1 < 0.2f)
        {
            charge1 += Time.deltaTime;
            if(charge1 >= 0.2f) controller.Charge(0);
        }

        if (ischarge2 && charge2 < 0.2f)
        {
            charge2 += Time.deltaTime;
            if(charge2 >= 0.2f) controller.Charge(1);
            
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        move = new Vector3(direction.x, 0, direction.y);
    }
    public void Attack1(InputAction.CallbackContext context)
    {
        if (context.started && !ischarge2)
        {
            ischarge1 = true;
            charge1 = 0;
        }
        else if (context.canceled && ischarge1)
        {
            controller.Attack(0,charge1);
            ischarge1 = false;
        }
    }

    public void Attack2(InputAction.CallbackContext context)
    {
        if (context.started && !ischarge1)
        {
            ischarge2 = true;
            charge2 = 0;
        }
        else if (context.canceled && ischarge2)
        {
            controller.Attack(1,charge2);
            ischarge2 = false;
        }
    }
}
