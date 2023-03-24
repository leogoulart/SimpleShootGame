using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public delegate void ChangeAimUIHandler(bool change);
    public static event ChangeAimUIHandler ChangeAIMUI;

    [SerializeField, Range(1,6)] private int viewDistance;

    private Transform cam;

    private Inventory inventory;

    private void Awake()
    {
        cam = Camera.main.transform;
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (GameManagement.Instance.GetCurrentGameState() == GAMESTATES.INGAME)
            Interaction();
    }

    void Interaction()
    {
        RaycastHit info;

        if(Physics.Raycast(cam.position, cam.forward, out info, viewDistance, LayerMask.GetMask("Collectables")))
        {
            if(!info.collider.isTrigger && !info.transform.IsChildOf(transform.root))
            {
                ChangeAIMUI?.Invoke(true);
                if (GameInputs.Instance.GetPlayerInteracted())
                {

                    CollectableItem item = info.transform.gameObject.GetComponent<CollectableItem>();
                    if(item != null)
                    {
                        inventory.CollectItem(item);
                    }
                }
            }
        }
        else
            ChangeAIMUI?.Invoke(false);
    }
}
