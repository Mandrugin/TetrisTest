using UnityEngine;
using System.Collections.Generic;
using strange.extensions.mediation.impl;

public class ScoreMediator : Mediator {

    private const string PREFAB_PATH = "ScoreCanvas";
    private ScoreComponent viewComponent;

    public override void OnRegister()
    {
        //ViewComponent = GameObject.Instantiate(Resources.Load(PREFAB_PATH));
        //viewComponent = View.GetComponentInChildren<ScoreComponent>();
        //viewComponent.UpdateScore(0);
    }

    //public override IList<string> ListNotificationInterests()
    //{
    //    List<string> notificationList = new List<string>();
    //    notificationList.Add(NotificationType.SCORE_VIEW_UPDATE_NOTE);

    //    return notificationList;
    //}

    //public override void HandleNotification(INotification notification)
    //{
    //    switch (notification.Name)
    //    {
    //        case NotificationType.SCORE_VIEW_UPDATE_NOTE:
    //            viewComponent.UpdateScore((int)notification.Body);
    //            break;
    //    }
    //}
}
