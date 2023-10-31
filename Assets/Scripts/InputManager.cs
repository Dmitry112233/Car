using UnityEngine;
using UnityEngine.UI;

public class InputManager : Singleton<InputManager>
{
    private VariableJoystick movementJoystick;

    public delegate void HorizontalHandler(float horizontal, float vertical);
    public event HorizontalHandler NotifyMovement;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private void Start()
    {
        movementJoystick = GameObject.FindGameObjectWithTag(GameData.JoystickTags.MovementJoystick).GetComponent<VariableJoystick>();
    }

    void Update()
    {
        Horizontal = movementJoystick.Horizontal;
        Vertical = movementJoystick.Vertical;

        NotifyMovement?.Invoke(Horizontal, Vertical);
    }
}
