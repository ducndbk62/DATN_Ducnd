using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float tankSpeed;
    public float rotateSpeed;
    public AudioClip moveSound;
    public AudioClip idleSound;
    public Joystick joystick;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = idleSound;
        audioSource.Play();
        audioSource.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Rotate(new Vector3(0, 1, 0), -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Rotate(new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Translate(Vector3.back * tankSpeed * Time.deltaTime);
        }
#endif

        if (joystick.Horizontal < -0.2f)
        {
            audioSource.clip = moveSound;
            audioSource.Play();

            transform.Rotate(new Vector3(0, 1, 0), -rotateSpeed * Time.deltaTime);
        }
        if (joystick.Horizontal > 0.2f)
        {
            audioSource.clip = moveSound;
            audioSource.Play();

            transform.Rotate(new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);
        }
        
        if (joystick.Vertical > 0.2f)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime);
        }

        if (joystick.Vertical < -0.2f)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
            transform.Translate(Vector3.back * tankSpeed * Time.deltaTime);
        }
    }
}
