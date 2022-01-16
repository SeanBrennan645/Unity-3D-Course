using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    Debug.Log("Hit something friendly");
                    break;
                }
            case "Fuel":
                {
                    Debug.Log("Gained some fuel!");
                    break;
                }
            case "Finish":
                {
                    Debug.Log("Reached the end");
                    break;
                }
            default:
                {
                    Debug.Log("Oh no hit an obstacle");
                    break;
                }
        }
    }
}
