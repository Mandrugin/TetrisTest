using strange.extensions.mediation.impl;
using UnityEngine;

class MainMenuMediator : Mediator
{
    [Inject]
    public MainMenuView view { get; set; }

    [Inject]
    public InitGameFieldSignal initGameFieldSignal { get; set; }


    public override void OnRegister()
    {
        view.startButtonClickedSignal.AddListener(OnStart);
        view.exitButtonClickedSignal.AddListener(OnExit);
    }

    public override void OnRemove()
    {
        view.startButtonClickedSignal.RemoveListener(OnStart);
        view.exitButtonClickedSignal.RemoveListener(OnExit);
    }

    private void OnStart()
    {
        initGameFieldSignal.Dispatch();
        Destroy(gameObject);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
