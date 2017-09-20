using UnityEngine;

public class KeyboardController : IInputController
{
    private bool _unlockControl = true;

    public bool IsUp()
    {
        return _unlockControl && Input.GetKeyDown(KeyCode.UpArrow);
    }

    public bool IsDown()
    {
        return _unlockControl && Input.GetKeyDown(KeyCode.DownArrow);
    }

    public bool IsRight()
    {
        return _unlockControl && Input.GetKeyDown(KeyCode.RightArrow);
    }

    public bool IsLeft()
    {
        return _unlockControl && Input.GetKeyDown(KeyCode.LeftArrow);
    }

    public bool IsEsc()
    {
        return _unlockControl && Input.GetKeyDown(KeyCode.Escape);
    }

    public void SetLock(bool isLock)
    {
        _unlockControl = !isLock;
    }
}