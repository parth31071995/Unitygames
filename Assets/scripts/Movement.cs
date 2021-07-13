using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 50f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem LeftThrsuters;
    [SerializeField] ParticleSystem RightThrsuters;
    [SerializeField] ParticleSystem ThrustElon;

    

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();

        }
    }

      void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeftAndThrust();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRightAndThrust();

        }
        else
        {
            StopRotatingThrusters();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
        if (!ThrustElon.isPlaying)
        {
            ThrustElon.Play();
        }
    }

     void StopThrusting()
    {
        audioSource.Stop();
        ThrustElon.Stop();
    }

  

      void RotateLeftAndThrust()
    {
        ApplyRotation(rotationThrust);
        if (!RightThrsuters.isPlaying)
        {
            RightThrsuters.Play();
        }
    }

    void RotateRightAndThrust()
    {
        ApplyRotation(-rotationThrust);
        if (!LeftThrsuters.isPlaying)
        {
            LeftThrsuters.Play();
        }
    }

     void StopRotatingThrusters()
    {
        RightThrsuters.Stop();
        LeftThrsuters.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}
