using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector3 inputVec;
    private Vector3 MoveVec;
    [SerializeField] CharacterController ChararcterCtr;
    [SerializeField] Animator animator;
    [SerializeField] Camera Maincam;
    public void OnMove(InputValue value)
    {
        inputVec.x = value.Get<Vector2>().x;
        inputVec.y = 0;
        inputVec.z = value.Get<Vector2>().y;
    }

    private void Update()
    {
        MoveVec = Maincam.transform.right * inputVec.x + Maincam.transform.forward * inputVec.z;
        MoveVec.y = 0;

        //Rotation
        if (MoveVec.magnitude > 0)
        {
            Quaternion dirQuat = Quaternion.LookRotation(MoveVec);
            Quaternion nextQuat = Quaternion.Slerp(transform.rotation, dirQuat, 0.3f);
            transform.rotation = nextQuat;
        }
        
    }

    private void FixedUpdate()
    {
        ChararcterCtr.Move((MoveVec) * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //애니메이션

    }
}
