using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private List<string> _levels;
    
    private string _activeScene;
    private int _activeSceneIndex;

    void Start()
    {
        _activeScene = SceneManager.GetActiveScene().name;

        // This list will hold all the scene names
        // Must update with each added level
        _levels = new List<string>
        {
            "SampleScene"
        };
    }

    // Might want to use as a catch or upon player death
    public void ReloadLevel()
    {
        SceneManager.LoadScene(_activeScene);
    }

    // Sends player to the next level
    // If player is on the final level, sends them to the start screen
    public void NextLevel()
    {
        _activeSceneIndex = _levels.IndexOf(_activeScene);

        if (_activeSceneIndex == -1)
        {
            Debug.LogError("Active scene is not currently in the List of levels");
            return;
        }

        if (_activeSceneIndex == _levels.Count - 1)
        {
            SceneManager.LoadScene("StartScreen");
            return;
        }

        SceneManager.LoadScene(_levels[_activeSceneIndex + 1]);
    }
}
