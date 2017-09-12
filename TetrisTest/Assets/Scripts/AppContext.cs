﻿using strange.extensions.context.api;
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
        injectionBinder.Bind<GameController>().To<GameController>();
        injectionBinder.Bind<IField>().To<GameField>().ToSingleton();
        //injectionBinder.Bind<IField>().To<NextField>().ToName("NEXT_FIELD").ToSingleton();

        mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
        mediationBinder.BindView<FieldViewComponent>().ToMediator<GameFieldViewMediator>();

        commandBinder.Bind(NotificationType.INIT_GAME_SCENE_NOTE).To<InitGameSceneCommand>();
        commandBinder.Bind(ContextEvent.START).To<StartupCommand>().Once();
    }
}