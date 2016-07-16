using PureMVC.Interfaces;
using PureMVC.Patterns;

/// <summary>
/// Application PureMVC Facade;
/// </summary>
public class AppFacade : Facade
{
    /// <summary>
    /// Facade Singleton Factory method.  This method is thread safe;
    /// </summary>
    public new static IFacade Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null) m_instance = new AppFacade();
                }
            }

            return m_instance;
        }
    }

    protected AppFacade()
    {
        // Protected constructor.
    }

    /// <summary>
    /// Start the application;
    /// </summary>
    /// <param name="app"></param>
    public void Startup(object app)
    {
        SendNotification(NotificationType.APP_STARTUP_NOTE, app);
    }

    /// <summary>
    /// Register Commands with the Controller
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotificationType.APP_STARTUP_NOTE, typeof(StartupCommand));
    }
}