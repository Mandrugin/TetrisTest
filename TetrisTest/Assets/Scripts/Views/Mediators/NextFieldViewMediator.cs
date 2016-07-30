using UnityEngine;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;

public class NextFieldViewMediator : Mediator
{
    new public static readonly string NAME = "NextFieldViewMediator";

    private FieldViewComponent viewComponent;
    private int height;
    private int width;
    private string prefabPath;

    public GameObject View
    {
        get { return (GameObject)ViewComponent; }
    }

    public NextFieldViewMediator() : base(NAME) {}

    public override void OnRegister()
    {
        prefabPath = "nextAreaCanvas";
        width = Tetramino.TETRAMINO_MAX_SIZE;
        height = Tetramino.TETRAMINO_MAX_SIZE;
        ViewComponent = GameObject.Instantiate(Resources.Load(prefabPath));
        viewComponent = View.GetComponentInChildren<FieldViewComponent>();
        viewComponent.Init(height, width);
    }

    public override void OnRemove()
    {
        GameObject.Destroy(View);
    }

    public override IList<string> ListNotificationInterests()
    {
        List<string> notificationList = new List<string>();
        notificationList.Add(NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE);

        return notificationList;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE:
                viewComponent.UpdateView((int[,])notification.Body);
                break;
        }
    }
}
