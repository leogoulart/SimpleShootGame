using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float walkSpeed, runSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start() => CameraFollow.Instance.AttachCamera(transform.Find("POV"));

    private void Update()
    {
        if (GameManagement.Instance.GetCurrentGameState() == GAMESTATES.INGAME)
            Movement(GameInputs.Instance.GetPlayerMovement());
    }

    void Movement(Vector2 input)
    {
        float finalSpeed;

        if (GameInputs.Instance.GetPlayerRunningThisFrame())
            finalSpeed = runSpeed;
        else
            finalSpeed = walkSpeed;

        Vector3 moveDir = transform.TransformVector(new Vector3(input.x, 0, input.y));
        controller.Move(moveDir * finalSpeed * Time.deltaTime);
    }
}
