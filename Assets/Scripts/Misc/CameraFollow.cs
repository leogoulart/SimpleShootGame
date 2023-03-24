using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private Transform body;
    private CinemachineVirtualCamera vCam;
    private static CameraFollow instance;

    public static CameraFollow Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void AttachCamera(Transform target)
    {
        body = target.root;
        vCam.Follow = target;
        vCam.LookAt = target;

        ShowHideCursor();
    }

    private void LateUpdate()
    {
        if (GameManagement.Instance.GetCurrentGameState() == GAMESTATES.INGAME)
            vCam.enabled = true;
        else
            vCam.enabled = false;

        if (GameManagement.Instance.GetCurrentGameState() == GAMESTATES.INGAME && body != null)
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(0, transform.eulerAngles.y, 0), 100 * Time.deltaTime);
    }

    public void ShowHideCursor()
    {
        if (GameManagement.Instance.GetCurrentGameState() == GAMESTATES.INGAME)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
