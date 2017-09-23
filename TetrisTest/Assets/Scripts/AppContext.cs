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

    protected override void mapBindings()
    {
        MapInjectionBinder();
        MapMediationBinder();
        MapCommandBinder();
    }

    private void MapCommandBinder()
    {
        commandBinder.Bind(NotificationType.DEINIT_GAME_SCENE_NOTE).To<DeinitGameSceneCommand>();
        commandBinder.Bind(NotificationType.INIT_GAME_FIELDS_NOTE).To<InitGameFieldsCommand>();
        commandBinder.Bind(NotificationType.GET_SCORE_LINES_REMOVED_NOTE).To<GetScoreLinesRemovedCommand>();
        commandBinder.Bind(NotificationType.CREATE_RECORD_VIEW_NOTE).To<CreateRecordViewCommand>();
        commandBinder.Bind(NotificationType.GAME_OVER_NOTE).InSequence().To<CheckPlayerRecordsCommand>().To<GameOverCommand>();
        commandBinder.Bind(NotificationType.MAIN_MENU_CRATE_NOTE).To<MainMenuCommand>();
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();

        // ...
        commandBinder.Bind(NotificationType.SAVE_PLAYER_DATA).To<SavePlayerDataCommand>();
        commandBinder.Bind(NotificationType.LOAD_PLAYER_DATA).To<LoadPlayerDataCommand>();
        commandBinder.Bind(NotificationType.CLEAR_PLAYER_DATA).To<ClearPlayerDataCommand>();
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
    }
}
