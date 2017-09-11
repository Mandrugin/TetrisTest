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
        injectionBinder.Bind<Field>().To<GameField>().ToName("GAME_FIELD");
        injectionBinder.Bind<Field>().To<NextField>().ToName("NEXT_FIELD");

        mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();

        commandBinder.Bind(ContextEvent.START).To<StartupCommand>().Once();
    }
}