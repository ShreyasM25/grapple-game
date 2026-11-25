using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class StartScreenManager : MonoBehaviour
{
    private VisualElement _root;
    private Button _startButton;
    private DropdownField _levelDropdown;

    private void Start()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;

        // Retrieving the Level Selector dropdown and setting its options
        _levelDropdown = _root.Q<DropdownField>("LevelSelector");
        _levelDropdown.choices = new List<string>
        {
            "Level 1"
        };
        // Setting the dropdown base value
        _levelDropdown.value = "Level 1";

        // Calling StartGame function upon pressing the Start Button
        _startButton = _root.Q<Button>("StartButton");
        _startButton.clicked += StartGame;
    }

    // Starts the game on the level the dropdown is currently set on
    private void StartGame()
    {
        string selectedLevel = _levelDropdown.value;
        switch (selectedLevel)
        {
            case "Level 1":
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
