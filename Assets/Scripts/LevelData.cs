using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Vector3 initCarPosition;
    public GameObject map;
    public Finish finish;
    public int TimeDuration;

    public void SetMapActivity(bool isActive)
    {
        map.SetActive(isActive);
    }
}
