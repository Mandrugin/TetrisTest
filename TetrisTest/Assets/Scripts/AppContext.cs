using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class AppContext : MVCSContext
{
    public AppContext(MonoBehaviour view) : base(view)
    {
    }

    public AppContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override void Launch()
    {
        base.Launch();
        //Make sure you've mapped this to a StartCommand!
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    }

    protected override void mapBindings()
    {
        MapInjectionBinder();
        MapMediationBinder();
        MapCommandBinder();
    }

    private void MapCommandBinder()
    {
        commandBinder.Bind<DeinitGameFieldSignal>().To<DeinitGameSceneCommand>();
        commandBinder.Bind<InitGameFieldSignal>().To<InitGameFieldsCommand>();
        commandBinder.Bind<GetScoreLinesRemovedSignal>().To<GetScoreLinesRemovedCommand>();
        commandBinder.Bind<CreateRecordViewSignal>().To<CreateRecordViewCommand>();
        commandBinder.Bind<GameOverSignal>().InSequence().To<CheckPlayerRecordsCommand>().To<GameOverCommand>();
        commandBinder.Bind<CreateMainMenuSignal>().To<MainMenuCommand>();
        commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

        // ...
        commandBinder.Bind<SavePlayerDataSignal>().To<SavePlayerDataCommand>();
        commandBinder.Bind<LoadPlayerDataSignal>().To<LoadPlayerDataCommand>();
        commandBinder.Bind<ClearPlayerDataSignal>().To<ClearPlayerDataCommand>();
    }

    private void MapMediationBinder()
    {
        mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
        mediationBinder.BindView<ScoreView>().ToMediator<ScoreMediator>();
        mediationBinder.BindView<FieldView>().ToMediator<GameFieldMediator>();
        mediationBinder.BindView<RecordView>().ToMediator<RecordMediator>();
        mediationBinder.BindView<GameOverView>().ToMediator<GameOverMediator>();
#if UNITY_ANDROID
        mediationBinder.BindView<InputView>().ToMediator<InputMediator>();
#endif
    }

    private void MapInjectionBinder()
    {
#if !UNITY_ANDROID
        injectionBinder.Bind<IInputController>().To<KeyboardController>().ToSingleton();
#else
        injectionBinder.Bind<IInputController>().To<ButtonsController>().ToSingleton();
#endif
        injectionBinder.Bind<IField>().To<GameField>().ToName("GAME_FIELD");
        injectionBinder.Bind<IField>().To<NextField>().ToName("NEXT_FIELD");
        injectionBinder.Bind<Score>().To<Score>().ToSingleton();
        injectionBinder.Bind<PlayerStats>().To<PlayerStats>().ToSingleton();
        injectionBinder.Bind<IDataSaver>().To<DataSaver>().ToSingleton();

        // signals
        injectionBinder.Bind<GameFieldUpdateSignal>().ToSingleton();
        injectionBinder.Bind<NextFieldUpdateSignal>().ToSingleton();
        injectionBinder.Bind<DestroyFieldsViewSignal>().ToSingleton();
        injectionBinder.Bind<ScoreViewUpdateSignal>().ToSingleton();
        injectionBinder.Bind<DestroyScoreViewSignal>().ToSingleton();
        injectionBinder.Bind<RecordWindowClosedSignal>().ToSingleton();
        injectionBinder.Bind<DestroyButtonsViewSignal>().ToSingleton();
    }
}
