using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector3 offset = new Vector3(0, 2, 3); // ī�޶�� �÷��̾� ������ ��� ��ġ
    public float followSpeed = 5f; // ���󰡴� �ӵ�

    void LateUpdate()
    {
        if (player == null)
            return;

        // ī�޶� ��ǥ ��ġ�� �ε巴�� �̵�
        Vector3 targetPosition = player.position + offset; // �÷��̾� ��ġ + ������
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // �÷��̾ �׻� �ٶ�
        transform.LookAt(player);
    }


}
