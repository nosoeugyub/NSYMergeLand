using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // NPC ������ (�̸� Unity �����Ϳ��� �Ҵ�)
    public GameObject npcPrefab;

    // NPC ������Ʈ ���� �Լ�
    public  GameObject CreateNPC(BaseCharacterData characterData)
    {
        // NPC ������Ʈ ����
        GameObject npcObject = Instantiate(npcPrefab);

        // ������ NPC ������Ʈ�� �����͸� ���� (�̸�, ��ġ ��)
        npcObject.name = characterData.Name.ToString();  // ��: NPC�� �̸��� UserId�� ����

        // NPC�� ��ġ�� ���� (���÷� ���� ��ġ)
        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), 0f, UnityEngine.Random.Range(-10f, 10f));
        npcObject.transform.position = randomPosition;

        // �ʿ��� ������Ʈ�� �ִϸ��̼� �߰� �� �ٸ� ������ �� �� �ֽ��ϴ�.
        // ���� ���, NPC�� �ִϸ��̼� �����̳� UI �ؽ�Ʈ�� ������ �� �ֽ��ϴ�.
        // npcObject.GetComponent<Animator>().Play("Idle");

        // �� NPC ������Ʈ�� ���� ���� ��ġ�մϴ�.
        return npcObject;
    }
}
