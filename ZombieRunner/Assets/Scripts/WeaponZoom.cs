﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60.0f;
    [SerializeField] float zoomedInFOV = 20.0f;

    private bool zoomedInToggle = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle)
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
            else
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }
        }
    }
}
