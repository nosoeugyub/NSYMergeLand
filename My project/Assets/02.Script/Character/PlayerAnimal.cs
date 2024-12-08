using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimal : BaseCharacter
{
    private Vector3 inputVec;
    private Vector3 MoveVec;
    private float moveSpeed = 1.0f;

    [SerializeField] CharacterController ChararcterCtr;
    [SerializeField] Animator animator;
    [SerializeField] Camera Maincam;
    public void OnMove(InputValue value)
    {
        inputVec.x = value.Get<Vector2>().x;
        inputVec.y = 0;
        inputVec.z = value.Get<Vector2>().y;
    }

    public override void Update()
    {
        if(Charaterdata == null)
        {
            return;
        }

        MoveVec = Maincam.transform.right * inputVec.x + Maincam.transform.forward * inputVec.z;
        MoveVec.y = 0;

        //Rotation
        if (MoveVec.magnitude > 0)
        {
            Quaternion dirQuat = Quaternion.LookRotation(MoveVec);
            Quaternion nextQuat = Quaternion.Slerp(transform.rotation, dirQuat, 0.3f);
            transform.rotation = nextQuat;
        }

        bool isMoving = MoveVec.magnitude > 0.1f;

        if (isMoving && !(stateManager.CurrentState is CharacterWalkingState))
        {
            stateManager.ChangeState(new CharacterWalkingState(this), this); // WalkState�� ��ȯ
        }
        else if (!isMoving && !(stateManager.CurrentState is CharacterIdleState))
        {
            stateManager.ChangeState(new CharacterIdleState(this), this); // IdleState�� ��ȯ
        }
    }


    private void FixedUpdate()
    {
        ChararcterCtr.Move((MoveVec * moveSpeed) * Time.deltaTime);
    }

    public override void UpdateNeeds()//�ǽð� �屸 ���� �Լ�
    {
    }

    public override void CheckAndChargeState() //�ش� �屸�� ���� �ص� ��ȯ �Լ�
    {
    }
}
