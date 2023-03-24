using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAMESTATES
{
    MAINMENU,
    INGAME,
    PAUSED
}

public class GameManagement : MonoBehaviour
{
    private static GameManagement instance;

    public static GameManagement Instance
    {
        get => instance;
    }

    [SerializeField] private GAMESTATES currentGameState = GAMESTATES.INGAME;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public GAMESTATES GetCurrentGameState() => currentGameState;

    public void UpdateGameState(GAMESTATES newState)
    {
        if (currentGameState != newState)
        {
            currentGameState = newState;
        }
    }

    private void Update()
    {
        if (GameInputs.Instance.GetPauseUnPauseAction())
        {
            if (currentGameState == GAMESTATES.INGAME || currentGameState == GAMESTATES.PAUSED)
                PauseUnPauseGame();
            else if (currentGameState == GAMESTATES.MAINMENU)
                print("Deseja sair do jogo?");
        }
    }

    #region Basic Game Controlls

    private void PauseUnPauseGame()
    {
        if (currentGameState == GAMESTATES.INGAME)
            UpdateGameState(GAMESTATES.PAUSED);
        else if (currentGameState == GAMESTATES.PAUSED)
            UpdateGameState(GAMESTATES.INGAME);
        CameraFollow.Instance.ShowHideCursor();
    }

    #endregion
}
