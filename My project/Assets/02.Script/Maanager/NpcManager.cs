using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // NPC 프리팹 (미리 Unity 에디터에서 할당)
    public GameObject npcPrefab;

    // NPC 오브젝트 생성 함수
    public  GameObject CreateNPC(BaseCharacterData characterData)
    {
        // NPC 오브젝트 생성
        GameObject npcObject = Instantiate(npcPrefab);

        // 생성된 NPC 오브젝트에 데이터를 설정 (이름, 위치 등)
        npcObject.name = characterData.Name.ToString();  // 예: NPC의 이름을 UserId로 설정

        // NPC의 위치를 설정 (예시로 랜덤 위치)
        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), 0f, UnityEngine.Random.Range(-10f, 10f));
        npcObject.transform.position = randomPosition;

        // 필요한 컴포넌트나 애니메이션 추가 등 다른 설정을 할 수 있습니다.
        // 예를 들어, NPC의 애니메이션 설정이나 UI 텍스트를 연결할 수 있습니다.
        // npcObject.GetComponent<Animator>().Play("Idle");

        // 이 NPC 오브젝트를 게임 씬에 배치합니다.
        return npcObject;
    }
}
