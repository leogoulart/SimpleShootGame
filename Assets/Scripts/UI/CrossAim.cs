using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossAim : MonoBehaviour
{
    [SerializeField]private Sprite defaultAim;
    [SerializeField]private Sprite grabAim;

    [SerializeField] private Image aim;

    private void Awake()
    {
        defaultAim = Resources.Load<Sprite>("UI/crosshair");
        grabAim = Resources.Load<Sprite>("UI/grab_hand");

        PlayerInteraction.ChangeAIMUI += ChangeAim;
    }

    void ChangeAim(bool isGrab)
    {
        if(isGrab)
        {
            aim.sprite = grabAim;
            aim.GetComponent<RectTransform>().sizeDelta = Vector2.one * 50;
        }
        else
        {
            aim.sprite = defaultAim;
            aim.GetComponent<RectTransform>().sizeDelta = Vector2.one * 16;
        }
    }

    private void OnDisable()
    {
        PlayerInteraction.ChangeAIMUI -= ChangeAim;
    }

}
