using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay =1.0f;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] AudioClip winAudio;

    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem winParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        isTransitioning = false;
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
        isTransitioning = false;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        // add death effects
        if (!isTransitioning)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(deathAudio);
            deathParticles.Play();
            isTransitioning = true;
        }
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LoadDelay);
    }

    void StartWinSequence()
    {
        // add sfx to win
        if (!isTransitioning)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(winAudio);
            winParticles.Play();
            isTransitioning = true;
        }
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LoadDelay);
    }
}
