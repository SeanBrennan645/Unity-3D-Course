using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Bindings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction mouseClick;

    [Header("General Setup Settings")]
    [Tooltip("Speed of Ship")][SerializeField] float controlSpeed = 30.0f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [Header("Laser Array")]
    [SerializeField] GameObject[] lasers;

    [Header("Rotation Settings")]
    [SerializeField] float positionPitchFactor = -5.0f;
    [SerializeField] float controlPitchFactor  = -20.0f;
    [SerializeField] float positionYawFactor = 5.0f;
    [SerializeField] float controlRollFactor = -20.0f;

    float yThrow;
    float xThrow;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
        mouseClick.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        mouseClick.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateRotation();
        ProcessFiring();
    }

    private void UpdatePosition()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        //TODO: as I'm using new input system will need to interpolate the vectors for smooth keyboard movement

        //float horizontalThrow = Input.GetAxis("Horizontal"); old system
        //float vertialThrow = Input.GetAxis("Vertical"); old system

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, 2 * yRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }

    private void UpdateRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (mouseClick.ReadValue<float>() >= 0.5)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
