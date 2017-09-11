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
        SceneManager.LoadScene("main");
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
