using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1.0f;
    [SerializeField] float rotationThrust = 1.0f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem LeftBooster;
    [SerializeField] ParticleSystem RightBooster;
    [SerializeField] ParticleSystem MainBooster;

    Rigidbody rigidb;
    AudioSource audioSource;



    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

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
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
    {
        rigidb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
            MainBooster.Play();
        }
    }
    private void StopThrusting()
    {
        audioSource.Stop();
        MainBooster.Stop();
    } 

    private void StopRotating()
    {
        RightBooster.Stop();
        LeftBooster.Stop();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!LeftBooster.isPlaying)
        {
            LeftBooster.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!RightBooster.isPlaying)
        {
            RightBooster.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidb.freezeRotation = true; // freezing rotation so we can maunally rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidb.freezeRotation = false;
    }
}
