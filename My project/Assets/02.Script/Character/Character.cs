using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public StateManager<Character> stateManager = new StateManager<Character>();

    private void Update()
    {
        stateManager.Update(this);
    }

    internal void CharacterIdleEnter()
    {
        throw new NotImplementedException();
    }

    internal void CharacterIdleExcute()
    {
        throw new NotImplementedException();
    }

    internal void CharacterIdleExit()
    {
        throw new NotImplementedException();
    }
}
