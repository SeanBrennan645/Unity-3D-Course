using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speedScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xValue = Input.GetAxis("Horizontal") * speedScale * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * speedScale * Time.deltaTime;

        transform.Translate(xValue, 0, zValue);
    }
}
