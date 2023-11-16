using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private VariableJoystick movementJoystick;

    public delegate void HorizontalHandler(float horizontal, float vertical);
    public delegate void BreakHandler();

    public event HorizontalHandler NotifyMovement;
    public event BreakHandler NotifyBreakStart;
    public event BreakHandler NotifyBreakFinish;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private void Start()
    {
        movementJoystick = GameObject.FindGameObjectWithTag(GameData.Tags.MovementJoystick).GetComponent<VariableJoystick>();
    }

    void Update()
    {
        Horizontal = movementJoystick.Horizontal;
        Vertical = movementJoystick.Vertical;

        Debug.Log(Horizontal + " - " + Vertical);

        NotifyMovement?.Invoke(Horizontal, Vertical);
    }

    public void BreakStart()
    {
        NotifyBreakStart?.Invoke();
    }

    public void BreakFinished()
    {
        NotifyBreakFinish?.Invoke();
    }
}
