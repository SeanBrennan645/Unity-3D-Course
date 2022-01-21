using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startingPosition;

    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateOscilation();
    }

    private void CalculateOscilation()
    {
        if (period <= Mathf.Epsilon) { return; } //epsilon is smallest float value and better comparison than 0.0f
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2; //tau is mathematical equivilant to 2Pi
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1.0f) / 2.0f; //raw wave range is -1 to 1 adding one increases factor range to 0-2 so need to divide by 2 to rescale

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
