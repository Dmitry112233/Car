using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentLevel = 0;
    public int nextLevel = 1;

    public List<GameObject> maps;

    public GameObject car;
    public GameObject canvasControlls;
    public GameObject inputManager;

    public GameObject canvasCompleted;
    public GameObject canvasFailed;

    void Start()
    {
        ActivateLevel(currentLevel);
    }

    void Update()
    {

    }

    private void LevelCompleted()
    {
        car.GetComponent<CarController>().Deactivate();
        inputManager.SetActive(false);
        canvasControlls.SetActive(false);

        canvasCompleted.SetActive(true);
    }

    private void LevelFailed()
    {
        car.GetComponent<CarController>().Deactivate();
        inputManager.SetActive(false);
        canvasControlls.SetActive(false);

        canvasCompleted.SetActive(true);
    }

    private void ActivateLevel(int levelNumber)
    {
        foreach(GameObject levelObj in maps)
        {
            var levelData = levelObj.GetComponent<LevelData>();
            if (levelData.map.activeSelf)
            {
                levelData.SetMapActivity(false);
            }
        }

        maps[levelNumber].GetComponent<LevelData>().SetMapActivity(true);

        canvasControlls.SetActive(true);
        inputManager.SetActive(true);

        if (!car.activeSelf)
        {
            car.SetActive(true);
        }

        car.GetComponent<CarController>().Activate();
        car.transform.position = (Vector3)(maps[levelNumber]?.GetComponent<LevelData>().initCarPosition);
    }
}
