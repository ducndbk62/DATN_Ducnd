using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksAnimation : MonoBehaviour
{
    public Joystick moveJoystick;

    private Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(moveJoystick.Horizontal) >= 0.2f || Mathf.Abs(moveJoystick.Vertical) >= 0.2f)
            anima.Play("TankTrackMove");
        else anima.Play("Idle");
    }
}
