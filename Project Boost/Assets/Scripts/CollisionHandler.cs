using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay =1.0f;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    Debug.Log("Hit something friendly");
                    break;
                }
            //case "Fuel":
            //    {
            //        Debug.Log("Gained some fuel!");
            //        break;
            //    }
            case "Finish":
                {
                    Debug.Log("Reached the end");
                    StartWinSequence();
                    break;
                }
            default:
                {
                    Debug.Log("Oh no hit an obstacle");
                    StartCrashSequence();
                    break;
                }
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        // add death effects
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LoadDelay);
    }

    void StartWinSequence()
    {
        // add sfx to win
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LoadDelay);
    }
}
