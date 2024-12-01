using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "ContextController")]
public class ContextContainer : ScriptableObject
{

    public Vector2 MoveVec;


    public void OnMove(InputValue value)
    {
        MoveVec = value.Get<Vector2>();
        Debug.Log(MoveVec);
    }

    public void Interection(InputAction.CallbackContext context)
    {

    }

}
