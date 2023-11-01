using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Vector3 initCarPosition;
    public GameObject map;

    public void SetMapActivity(bool isActive)
    {
        map.SetActive(isActive);
    }
}
