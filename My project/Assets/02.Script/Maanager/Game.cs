using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public StateManager<Game> stateManager = new StateManager<Game>();

    public void PauseGAme()
    {

    }

    public void ResumGame()
    {

    }


    // Update is called once per frame
    void Update()
    {
        stateManager.Update(this);
    }

    internal void EnterGameStart()
    {
        throw new NotImplementedException();
    }

    internal void EnterGameExit()
    {
        throw new NotImplementedException();
    }

    internal void EnterGameExcute()
    {
        throw new NotImplementedException();
    }

    internal void PauseGame()
    {
        throw new NotImplementedException();
    }

    internal void UpdateGamePause()
    {
        throw new NotImplementedException();
    }

    internal void ExitGamePause()
    {
        throw new NotImplementedException();
    }


}
