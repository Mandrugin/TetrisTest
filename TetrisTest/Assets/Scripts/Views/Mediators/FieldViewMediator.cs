using strange.extensions.mediation.impl;

public class GameFieldMediator : Mediator
{
    [Inject]
    public FieldView View { get; set; }
    private int height;
    private int width;

    [Inject]
    public GameFieldUpdateSignal gameFieldUpdateSignal { get; set; }

    [Inject]
    public NextFieldUpdateSignal nextFieldUpdateSignal { get; set; }

    [Inject]
    public DestroyFieldsViewSignal destroyFieldsViewSignal { get; set; }

    public override void OnRegister()
    {
        if (View.NAME == "GAME")
        {
            width = ConstStorage.HORIZONTAL_SIZE;
            height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
            View.Init(height, width);

            gameFieldUpdateSignal.AddListener(OnUpdate);
        }
        
        if (View.NAME == "NEXT")
        {
            width = Tetramino.TETRAMINO_MAX_SIZE;
            height = Tetramino.TETRAMINO_MAX_SIZE;
            View.Init(height, width);

            nextFieldUpdateSignal.AddListener(OnUpdate);
        }

        destroyFieldsViewSignal.AddListener(OnSelfDestroy);
    }

    public override void OnRemove()
    {
        if (View.NAME == "GAME")
        {
            gameFieldUpdateSignal.RemoveListener(OnUpdate);
        }

        if (View.NAME == "NEXT")
        {
            nextFieldUpdateSignal.RemoveListener(OnUpdate);
        }

        destroyFieldsViewSignal.RemoveListener(OnSelfDestroy);
    }

    public void OnUpdate(int[,] fieldInfo)
    {
        View.UpdateView(fieldInfo);
    }

    private void OnSelfDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
