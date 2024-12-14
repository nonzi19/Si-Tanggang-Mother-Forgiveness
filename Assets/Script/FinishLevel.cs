using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // The name of the scene to load when the level is finished
    public string nextLevelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call a method to handle level completion (e.g., show a victory screen)
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        // Add any logic here for what should happen when the level is completed
        Debug.Log("Level completed!");

        // Load the next level
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogWarning("Next level name not set in the FinishLevel script.");
        }
    }
}
