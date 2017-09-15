using System.Diagnostics;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class GameFieldViewMediator : EventMediator {

    [Inject]
    public FieldViewComponent viewComponent { get; set; }
    private int height;
    private int width;

    public override void OnRegister()
    {
        UnityEngine.Debug.Log("RegisterMediator: " + viewComponent.NAME);
        if (viewComponent.NAME == "GAME")
        {
            width = ConstStorage.HORIZONTAL_SIZE;
            height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
            viewComponent.Init(height, width);

            dispatcher.AddListener(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
        
        if (viewComponent.NAME == "NEXT")
        {
            width = Tetramino.TETRAMINO_MAX_SIZE;
            height = Tetramino.TETRAMINO_MAX_SIZE;
            viewComponent.Init(height, width);

            dispatcher.AddListener(NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
        UnityEngine.Debug.Log("RegisterMediator: " + viewComponent.NAME);
    }

    public override void OnRemove()
    {
        if (viewComponent.NAME == "GAME")
        {
            dispatcher.RemoveListener(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }

        if (viewComponent.NAME == "NEXT")
        {
            dispatcher.RemoveListener(NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
    }

    public void OnUpdate(IEvent e)
    {
        UnityEngine.Debug.Log("type: " + viewComponent.NAME + " [OnUpdate]");
        viewComponent.UpdateView((int[,])e.data);
    }
}
