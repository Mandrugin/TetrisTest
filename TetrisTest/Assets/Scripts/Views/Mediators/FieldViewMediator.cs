﻿using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class GameFieldMediator : EventMediator {

    [Inject]
    public FieldView View { get; set; }
    private int height;
    private int width;

    public override void OnRegister()
    {
        if (View.NAME == "GAME")
        {
            width = ConstStorage.HORIZONTAL_SIZE;
            height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
            View.Init(height, width);

            dispatcher.AddListener(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
        
        if (View.NAME == "NEXT")
        {
            width = Tetramino.TETRAMINO_MAX_SIZE;
            height = Tetramino.TETRAMINO_MAX_SIZE;
            View.Init(height, width);

            dispatcher.AddListener(NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
        UnityEngine.Debug.Log("RegisterMediator: " + View.NAME);
    }

    public override void OnRemove()
    {
        if (View.NAME == "GAME")
        {
            dispatcher.RemoveListener(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }

        if (View.NAME == "NEXT")
        {
            dispatcher.RemoveListener(NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
        }
    }

    public void OnUpdate(IEvent e)
    {
        UnityEngine.Debug.Log("type: " + View.NAME + " [OnUpdate]");
        View.UpdateView((int[,])e.data);
    }
}
