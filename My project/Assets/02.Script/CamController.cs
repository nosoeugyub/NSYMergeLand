using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 offset = new Vector3(0, 2, 3); // 카메라와 플레이어 사이의 상대 위치
    public float followSpeed = 5f; // 따라가는 속도

    void LateUpdate()
    {
        if (player == null)
            return;

        // 카메라가 목표 위치로 부드럽게 이동
        Vector3 targetPosition = player.position + offset; // 플레이어 위치 + 오프셋
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 플레이어를 항상 바라봄
        transform.LookAt(player);
    }


}
