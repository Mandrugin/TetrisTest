using strange.extensions.mediation.impl;

class GameOverMediator : EventMediator
{
    [Inject]
    public GameOverView vameOverView { get; set; }

    public override void OnRegister()
    {
        vameOverView.dispatcher.AddListener(GameOverView.Events.BUTTON_CLICKED, OnButtonClicked);
    }

    public override void OnRemove()
    {
        vameOverView.dispatcher.RemoveListener(GameOverView.Events.BUTTON_CLICKED, OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        dispatcher.Dispatch(NotificationType.DEINIT_GAME_SCENE_NOTE);
        Destroy(transform.parent.gameObject);
        dispatcher.Dispatch(NotificationType.MAIN_MENU_CRATE_NOTE);
    }
}
