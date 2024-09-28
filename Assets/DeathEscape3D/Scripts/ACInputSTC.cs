using UnityEngine;
using AC;

public class ACInputSTC : MonoBehaviour
{

    public SimpleTouchController moveController;
    public SimpleTouchController aimController;
    public float runThreshold = 0.8f;


    void Start()
    {
        KickStarter.playerInput.InputGetAxisDelegate = CustomGetAxis;
        KickStarter.playerInput.InputGetFreeAimDelegate = CustomGetFreeAim;
        KickStarter.playerInput.InputGetButtonDelegate = CustomGetButton;
    }


    private float CustomGetAxis(string axisName)
    {
        if (axisName == "Horizontal")
        {
            return moveController.GetTouchPosition.x;
        }
        if (axisName == "Vertical")
        {
            return moveController.GetTouchPosition.y;
        }

        try
        {
            return Input.GetAxis(axisName);
        }
        catch
        {
            return 0f;
        }
    }


    private Vector2 CustomGetFreeAim(bool cursorIsLocked)
    {
        return aimController.GetTouchPosition;
    }


    private bool CustomGetButton(string axisName)
    {
        if (axisName == "Run")
        {
            return moveController.GetTouchPosition.magnitude > runThreshold;
        }

        try
        {
            return Input.GetButton(axisName);
        }
        catch
        {
            return false;
        }
    }

}