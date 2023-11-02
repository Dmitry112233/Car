using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool IsFinished { get; set; }

    private void Start()
    {
        IsFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameData.Tags.Car)
        {
            IsFinished = true;
        }
    }
}
