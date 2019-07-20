using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Input;

public class Player : MonoBehaviour
{
    public MovementControll controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls.Gamepad.Movement.performed += fuckyou => Test(fuckyou.ReadValue<Vector2>());
     }

    // Update is called once per frame
    void Test(Vector2 direction)
    {
        Debug.Log("Testing movement");
    }

    public void onEnable()
    {
        controls.Enable();
    }

    public void onDisable()
    {
        controls.Disable();
    }
}
