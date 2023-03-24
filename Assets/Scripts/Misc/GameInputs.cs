using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    private GameControlls controlls;

    private static GameInputs instance;

    public static GameInputs Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        controlls = new GameControlls();
    }

    private void OnEnable() => controlls.Enable();

    private void OnDisable() => controlls.Disable();

    #region General Controlls

    public bool GetPauseUnPauseAction() => controlls.GeneralMap.PauseUnpause.WasPressedThisFrame();

    #endregion

    #region Player Controlls

    public Vector2 GetPlayerMovement() => controlls.PlayerMap.Movement.ReadValue<Vector2>();

    public bool GetPlayerRunningThisFrame() => controlls.PlayerMap.Running.IsPressed();

    public bool GetPlayerInteracted() => controlls.PlayerMap.Interaction.WasPressedThisFrame();

    #endregion

}
