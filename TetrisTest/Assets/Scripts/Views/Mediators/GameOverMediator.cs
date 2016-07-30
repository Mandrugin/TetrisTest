using UnityEngine;
using UnityEngine.SceneManagement;
using PureMVC.Patterns;

class GameOverMediator : Mediator
{
    new static readonly string NAME = "GameOverMediator";
    static readonly string PREFAB_PATH = "GameOverCanvas";
    private GameOverComponent viewComponent;

    public GameOverMediator() : base(NAME) {}

    public GameObject View
    {
        get { return (GameObject)ViewComponent; }
    }

    public override void OnRegister()
    {
        ViewComponent = GameObject.Instantiate(Resources.Load(PREFAB_PATH));
        viewComponent = View.GetComponentInChildren<GameOverComponent>();

        viewComponent.TitleText.text = "Game Over";
        viewComponent.ButtonText.text = "Return to menu";
        viewComponent.ActionButton.onClick.AddListener( () => {
            AppFacade.Instance.RemoveMediator(NAME);
            AppFacade.Instance.SendNotification(NotificationType.DEINIT_GAME_SCENE_NOTE);
            SceneManager.LoadScene("start");
        } );

    }

    public override void OnRemove()
    {
        GameObject.Destroy(View);
    }
}
