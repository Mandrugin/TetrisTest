using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

class GameOverMediator : Mediator
{
    static readonly string PREFAB_PATH = "GameOverCanvas";
    private GameOverComponent viewComponent;

    //public override void OnRegister()
    //{
    //    ViewComponent = GameObject.Instantiate(Resources.Load(PREFAB_PATH));
    //    viewComponent = View.GetComponentInChildren<GameOverComponent>();

    //    viewComponent.TitleText.text = "Game Over";
    //    viewComponent.ButtonText.text = "Return to menu";
    //    viewComponent.ActionButton.onClick.AddListener( () => {
    //        AppContext.Instance.RemoveMediator(NAME);
    //        AppContext.Instance.SendNotification(NotificationType.DEINIT_GAME_SCENE_NOTE);
    //        SceneManager.LoadScene("start");
    //    } );

    //}

    //public override void OnRemove()
    //{
    //    GameObject.Destroy(View);
    //}
}
