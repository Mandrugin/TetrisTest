using strange.extensions.mediation.impl;

public class InputMediator : Mediator
{
    [Inject]
    public InputView inputView { get; set; }

    [Inject]
    public DestroyFieldsViewSignal destroyFieldsViewSignal { get; set; }

    [Inject]
    public IInputController controller { get; set; }

    private ButtonsController _controller;

    public override void OnRegister()
    {
        _controller = controller as ButtonsController;

        inputView.upButtonClicked.AddListener(SetUp);
        inputView.downButtonClicked.AddListener(SetDown);
        inputView.leftButtonClicked.AddListener(SetLeft);
        inputView.rightButtonClicked.AddListener(SetRight);

        destroyFieldsViewSignal.AddListener(OnSelfDestroy);
    }

    public override void OnRemove()
    {
        inputView.upButtonClicked.RemoveListener(SetUp);
        inputView.downButtonClicked.RemoveListener(SetDown);
        inputView.leftButtonClicked.RemoveListener(SetLeft);
        inputView.rightButtonClicked.RemoveListener(SetRight);

        destroyFieldsViewSignal.RemoveListener(OnSelfDestroy);
    }

    public void SetUp()
    {
        _controller.SetUp();
    }

    public void SetDown()
    {
        _controller.SetDown();
    }

    public void SetLeft()
    {
        _controller.SetLeft();
    }

    public void SetRight()
    {
        _controller.SetRight();
    }

    private void OnSelfDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
