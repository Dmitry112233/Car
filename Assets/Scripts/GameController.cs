using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentLevel = 0;

    public List<LevelData> maps;

    public GameObject car;
    public Canvas controllsCanvas;

    public Canvas canvasLevelFinished;
    public TextMeshProUGUI titleText;
    public GameObject buttonNextLevel;
    public GameObject buttonRetry;

    public CameraControll virtualCamera;

    public Timer timer;

    private bool isLevelCompleted;

    void Start()
    {
        ActivateLevel();
        isLevelCompleted = false;
    }

    void Update()
    {
        if (maps[currentLevel].finish.IsFinished && !timer.IsFifnished)
        {
            isLevelCompleted = true;
            LevelFinished(true);
        }
        if (timer.IsFifnished && !isLevelCompleted)
        {
            LevelFinished(false);
        }
    }

    private void LevelFinished(bool isCompleted)
    {
        maps[currentLevel].finish.IsFinished = false;

        controllsCanvas.GetComponent<Canvas>().enabled = false;
        canvasLevelFinished.GetComponent<Canvas>().enabled = true;

        virtualCamera.Lens = 100;

        if (isCompleted)
        {
            buttonNextLevel.SetActive(true);
            buttonRetry.SetActive(false);
            titleText.SetText("Level Completed");
            if (currentLevel < maps.Count - 1)
            {
                currentLevel += 1;
            }
        }
        else
        {
            titleText.SetText("Level Failed");
            buttonNextLevel.SetActive(false);
            buttonRetry.SetActive(true);
        }
    }

    public void ActivateLevel()
    {
        isLevelCompleted = false;

        foreach (LevelData levelObj in maps)
        {
            levelObj.SetMapActivity(false);
        }

        maps[currentLevel].SetMapActivity(true);

        car.SetActive(false);

        car.transform.position = (Vector3)(maps[currentLevel]?.GetComponent<LevelData>().initCarPosition);
        car.transform.rotation = Quaternion.LookRotation(transform.forward);

        car.SetActive(true);

        canvasLevelFinished.GetComponent<Canvas>().enabled = false;
        controllsCanvas.GetComponent<Canvas>().enabled = true;

        virtualCamera.Lens = 50;

        timer.RestartTimer(maps[currentLevel].TimeDuration);
    }
}
