using strange.extensions.mediation.impl;
using UnityEngine;

class MainMenuMediator : EventMediator
{
    [Inject]
    public MainMenuView view { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(MainMenuView.Events.START_BUTTON_CLICKED, OnStart);
        view.dispatcher.AddListener(MainMenuView.Events.EXIT_BUTTON_CLICKED, OnExit);
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(MainMenuView.Events.START_BUTTON_CLICKED, OnStart);
        view.dispatcher.RemoveListener(MainMenuView.Events.EXIT_BUTTON_CLICKED, OnExit);
    }

    private void OnStart()
    {
        dispatcher.Dispatch(NotificationType.INIT_GAME_FIELDS_NOTE);
        Destroy(gameObject);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
