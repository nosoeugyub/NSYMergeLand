using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int gameindex = 0;
    private int maxgameindex = 5;

    public void Awake()
    {
        StartCoroutine(GameStartCoroutine());
    }

    private IEnumerator GameStartCoroutine()
    {
        while (gameindex < maxgameindex)
        {
            yield return null; // Wait until the next frame before continuing
            if (gameindex == 0)
            {
                GameEventSystem.Send_GameSequence(Utill_Eum.GameSequence.DataLoad);
                gameindex++;
            }
            else if (gameindex == 1)
            {
                GameEventSystem.Send_GameSequence(Utill_Eum.GameSequence.CreateData);
                gameindex++;
            }
            else if (gameindex == 2)
            {
                GameEventSystem.Send_GameSequence(Utill_Eum.GameSequence.Tutorial);
                gameindex++;
            }
            else if (gameindex == 3)
            {
                GameEventSystem.Send_GameSequence(Utill_Eum.GameSequence.GameSetting);
                gameindex++;
            }
            else if (gameindex == 4)
            {
                GameEventSystem.Send_GameSequence(Utill_Eum.GameSequence.GameStart);
                gameindex = -1; // End of the sequence
                yield break;
            }

            yield return null; // Wait until the next frame before continuing
        }
    }
}
