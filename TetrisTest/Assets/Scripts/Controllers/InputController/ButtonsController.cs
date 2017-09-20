
public class ButtonsController : IInputController
{
    private bool _up;
    private bool _down;
    private bool _left;
    private bool _right;

    private bool _unlockControl = true;

    public void SetUp() { _up = true; }
    public void SetDown() { _down = true; }
    public void SetLeft() { _left = true; }
    public void SetRight() { _right = true; }

    public bool IsUp()
    {
        bool temp = _up;
        _up = false;
        return _unlockControl && temp;
    }

    public bool IsDown()
    {
        bool temp = _down;
        _down = false;
        return _unlockControl && temp;
    }

    public bool IsRight()
    {
        bool temp = _right;
        _right = false;
        return _unlockControl && temp;
    }

    public bool IsLeft()
    {
        bool temp = _left;
        _left = false;
        return _unlockControl && temp;
    }

    public bool IsEsc()
    {
        return false;
    }

    public void SetLock(bool isLock)
    {
        _unlockControl = !isLock;
    }
}
