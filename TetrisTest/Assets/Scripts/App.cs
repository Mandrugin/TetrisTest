using UnityEngine;

public class App : MonoBehaviour
{
    public static App instance;

    protected void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected void Start()
    {
        Debug.Log("App Start");
        AppFacade facade = (AppFacade)AppFacade.Instance;
        facade.Startup(this);
    }
}