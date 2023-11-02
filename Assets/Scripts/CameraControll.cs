using Cinemachine;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float Lens { get; set; }

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Lens = 50;
    }

    void Update()
    {
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, Lens, 0.01f);
    }
}
