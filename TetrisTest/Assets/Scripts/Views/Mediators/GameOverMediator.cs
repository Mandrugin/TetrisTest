using strange.extensions.mediation.impl;

class GameOverMediator : Mediator
{
    [Inject]
    public GameOverView vameOverView { get; set; }

    [Inject]
    public DeinitGameFieldSignal deinitGameFieldSignal { get; set; }

    [Inject]
    public CreateMainMenuSignal createMainMenuSignal { get; set; }


    public override void OnRegister()
    {
        vameOverView.buttonClicked.AddListener(OnButtonClicked);
    }

    public override void OnRemove()
    {
        vameOverView.buttonClicked.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        deinitGameFieldSignal.Dispatch();
        Destroy(transform.parent.gameObject);
        createMainMenuSignal.Dispatch();
    }
}
