using strange.extensions.mediation.impl;

public class InputMediator : EventMediator
{
    [Inject]
    public InputView inputView { get; set; }

    [Inject]
    public IInputController controller { get; set; }

    private ButtonsController _controller;

    public override void OnRegister()
    {
        controller.SetLock(false);

        _controller = controller as ButtonsController;

        inputView.dispatcher.AddListener(InputView.Events.UP_BUTTON_CLICKED, SetUp);
        inputView.dispatcher.AddListener(InputView.Events.DOWN_BUTTON_CLICKED, SetDown);
        inputView.dispatcher.AddListener(InputView.Events.LEFT_BUTTON_CLICKED, SetLeft);
        inputView.dispatcher.AddListener(InputView.Events.RIGHT_BUTTON_CLICKED, SetRight);

        dispatcher.AddListener(NotificationType.DESTROY_FIELDS_VIEWS, OnSelfDestroy);
    }

    public override void OnRemove()
    {
        inputView.dispatcher.RemoveListener(InputView.Events.UP_BUTTON_CLICKED, SetUp);
        inputView.dispatcher.RemoveListener(InputView.Events.DOWN_BUTTON_CLICKED, SetDown);
        inputView.dispatcher.RemoveListener(InputView.Events.LEFT_BUTTON_CLICKED, SetLeft);
        inputView.dispatcher.RemoveListener(InputView.Events.RIGHT_BUTTON_CLICKED, SetRight);

        dispatcher.RemoveListener(NotificationType.DESTROY_FIELDS_VIEWS, OnSelfDestroy);
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
