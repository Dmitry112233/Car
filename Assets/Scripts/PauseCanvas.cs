using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    public Canvas pauseCanvas;

    private Button pauseButton;
    private Button continueButton;
    private Button leaveButton;

    void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag(GameData.Tags.PauseButton).GetComponent<Button>();
        continueButton = GameObject.FindGameObjectWithTag(GameData.Tags.ContinueButton).GetComponent<Button>();
        leaveButton = GameObject.FindGameObjectWithTag(GameData.Tags.LeaveButton).GetComponent<Button>();

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(() =>
            {
                Pause();
            });
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(() =>
            {
                ContinueGame();
            });
        }

        if (leaveButton != null)
        {
            leaveButton.onClick.AddListener(() =>
            {
                Leave();
            });
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.GetComponent<Canvas>().enabled = true;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pauseCanvas.GetComponent<Canvas>().enabled = false;
    }

    private void Leave()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
