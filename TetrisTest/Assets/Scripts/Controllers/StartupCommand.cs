using UnityEngine;
using UnityEngine.SceneManagement;
using PureMVC.Patterns;
using PureMVC.Interfaces;

/// <summary>
/// Startup application simple command;
/// </summary>
public class StartupCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SceneManager.LoadScene("start");
        Debug.Log("Startup command executed");
    }
}