using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private bool isOpenning;

    public void OnClickMinimap()
    {
        if (!isOpenning)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(3.5f, 3.5f, 3.5f);
            isOpenning = !isOpenning;
        }
        else
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            isOpenning = !isOpenning;
        }
    }
}
