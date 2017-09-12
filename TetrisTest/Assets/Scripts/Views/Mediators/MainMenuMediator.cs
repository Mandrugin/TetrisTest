using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

class MainMenuMediator : EventMediator
{
    [Inject]
    public MainMenuView view { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(MainMenuView.Events.START_BUTTON_CLICKED, OnStart);
        view.dispatcher.AddListener(MainMenuView.Events.START_BUTTON_CLICKED, OnExit);
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(MainMenuView.Events.START_BUTTON_CLICKED, OnStart);
        view.dispatcher.RemoveListener(MainMenuView.Events.START_BUTTON_CLICKED, OnExit);
    }

    private void OnStart()
    {
        Debug.Log("start button clicked!");
        dispatcher.Dispatch(NotificationType.INIT_GAME_SCENE_NOTE);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
