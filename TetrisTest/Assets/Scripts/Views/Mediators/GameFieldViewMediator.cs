using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class GameFieldViewMediator : EventMediator {

    [Inject]
    public FieldViewComponent viewComponent { get; set; }
    private int height;
    private int width;

    public override void OnRegister()
    {
        width = ConstStorage.HORIZONTAL_SIZE;
        height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
        viewComponent.Init(height, width);

        dispatcher.AddListener(NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE, OnUpdate);
    }

    public void OnUpdate(IEvent e)
    {
        viewComponent.UpdateView((int[,])e.data);
    }
}
