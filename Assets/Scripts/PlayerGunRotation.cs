using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotation : MonoBehaviour
{
    public Vector3 gunRotateSpeed;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal < -0.2f)
        {
            transform.Rotate(Vector3.up, -gunRotateSpeed.y * Mathf.Abs(joystick.Horizontal) * Time.deltaTime);
        }
        if (joystick.Horizontal > 0.2f)
        {
            transform.Rotate(Vector3.up, gunRotateSpeed.y * Mathf.Abs(joystick.Horizontal) * Time.deltaTime);
        }

        if (joystick.Vertical > 0.2f)
        {
            if (transform.rotation.x > -0.035f)
                transform.Rotate(Vector3.right, -gunRotateSpeed.x * Mathf.Abs(joystick.Vertical) * Time.deltaTime);
        }

        if (joystick.Vertical < -0.2f)
        {
            if (transform.rotation.x < 0.03f)
                transform.Rotate(Vector3.right, gunRotateSpeed.x * Mathf.Abs(joystick.Vertical) * Time.deltaTime);
        }
    }
}
