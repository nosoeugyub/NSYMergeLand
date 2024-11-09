using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : IState<Character>
{
    public void Enter(Character context)
    {
        context.CharacterIdleEnter();
    }

    public void Excute(Character context)
    {
        context.CharacterIdleExcute();
    }

    public void Exit(Character Context)
    {
        Context.CharacterIdleExit();
    }
}
