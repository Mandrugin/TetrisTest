public interface IInputController
{
    bool IsUp();
    bool IsDown();
    bool IsRight();
    bool IsLeft();
    bool IsEsc();
    void SetLock(bool isLock);
}