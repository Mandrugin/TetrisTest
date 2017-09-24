using strange.extensions.mediation.impl;

public class GameFieldMediator : Mediator
{
    [Inject]
    public FieldView View { get; set; }

    [Inject]
    public GameFieldUpdateSignal gameFieldUpdateSignal { get; set; }

    [Inject]
    public NextFieldUpdateSignal nextFieldUpdateSignal { get; set; }

    [Inject]
    public DestroyFieldsViewSignal destroyFieldsViewSignal { get; set; }

    public override void OnRegister()
    {
        var width = ConstStorage.HORIZONTAL_SIZE;
        var height = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
        View.gameField.Init(height, width);

        width = Tetramino.TETRAMINO_MAX_SIZE;
        height = Tetramino.TETRAMINO_MAX_SIZE;
        View.nextField.Init(height, width);

        gameFieldUpdateSignal.AddListener(View.gameField.UpdateView);
        nextFieldUpdateSignal.AddListener(View.nextField.UpdateView);

        destroyFieldsViewSignal.AddListener(OnSelfDestroy);
    }

    public override void OnRemove()
    {
        gameFieldUpdateSignal.RemoveListener(View.gameField.UpdateView);
        nextFieldUpdateSignal.RemoveListener(View.nextField.UpdateView);
        destroyFieldsViewSignal.RemoveListener(OnSelfDestroy);
    }

    private void OnSelfDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
