using UnityEngine;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;

public class GameFieldViewMediator : Mediator {

    new public static readonly string NAME = "GameFieldViewMediator";

    private FieldViewComponent viewComponent;
    private int height;
    private int width;
    private string prefabPath;

    public GameObject View
    {
        get { return (GameObject)ViewComponent; }
    }

    public GameFieldViewMediator() : base(NAME) {}

    public override void OnRegister()
    {
        prefabPath = "gameAreaCanvas";
        width = ConstStorage.HORIZONTAL_SIZE;
        height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
        ViewComponent = GameObject.Instantiate(Resources.Load(prefabPath));
        viewComponent = View.GetComponentInChildren<FieldViewComponent>();
        viewComponent.Init(height, width);
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }

    public override IList<string> ListNotificationInterests()
    {
        List<string> notificationList = new List<string>();
        notificationList.Add(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE);

        return notificationList;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE:
                viewComponent.UpdateView((int[,])notification.Body);
                break;
        }
    }
}
