using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restorAngle = 90.0f;
    [SerializeField] float addIntensity = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restorAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
