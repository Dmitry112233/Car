using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(() =>
            {
                StartGame();
            });
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
