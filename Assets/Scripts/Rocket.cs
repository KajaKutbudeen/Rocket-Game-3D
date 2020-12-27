using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource myaudio;
    [SerializeField] float rct = 100f;
    [SerializeField] float MainThurst = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
       Thrusting();
        Rotate();
    }

    private void Rotate()
    {
        float rotationSpeed = rct * Time.deltaTime;
        rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
        rigidbody.freezeRotation = false;
    }

    private void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * MainThurst);
            if (!myaudio.isPlaying)
            {
                myaudio.Play();
            }
        }
        else
        {
            myaudio.Stop();
        }
    }
}
