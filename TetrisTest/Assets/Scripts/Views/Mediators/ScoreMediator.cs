using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class ScoreMediator : Mediator {

    new public static readonly string NAME = "ScoreMediator";
    private const string PREFAB_PATH = "ScoreCanvas";
    private ScoreComponent viewComponent;

    public GameObject View
    {
        get { return (GameObject)ViewComponent; }
    }

    public ScoreMediator() : base(NAME) {}

    public override void OnRegister()
    {
        ViewComponent = GameObject.Instantiate(Resources.Load(PREFAB_PATH));
        viewComponent = View.GetComponentInChildren<ScoreComponent>();
        viewComponent.UpdateScore(0);
    }

    public override void OnRemove()
    {
        GameObject.Destroy(View);
    }

    public override IList<string> ListNotificationInterests()
    {
        List<string> notificationList = new List<string>();
        notificationList.Add(NotificationType.SCORE_VIEW_UPDATE_NOTE);

        return notificationList;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationType.SCORE_VIEW_UPDATE_NOTE:
                viewComponent.UpdateScore((int)notification.Body);
                break;
        }
    }
}
