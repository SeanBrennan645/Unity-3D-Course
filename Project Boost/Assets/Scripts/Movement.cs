using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1.0f;
    [SerializeField] float rotationThrust = 1.0f;
    Rigidbody rigidb;
    AudioSource thrustAudio;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        thrustAudio = GetComponent<AudioSource>();
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
            rigidb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!thrustAudio.isPlaying)
            {
                thrustAudio.Play();
            }
        }
        else
        {
            thrustAudio.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidb.freezeRotation = true; // freezing rotation so we can maunally rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidb.freezeRotation = false;
    }
}
