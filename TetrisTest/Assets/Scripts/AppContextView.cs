using strange.extensions.context.impl;

public class AppContextView : ContextView
{
    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
        context = new AppContext(this);
    }
}