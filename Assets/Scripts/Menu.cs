using UnityEngine;
using UnityEngine.SceneManagement;
using Esper.Freeloader;


public class Menu : MonoBehaviour
{
    public GameObject titlePanel;
    public void StartGame()
    {
        Debug.Log("StartGame button clicked!");
        if (titlePanel != null)
            titlePanel.SetActive(false);
        LoadingScreen.Instance.Load("Salon");
    }

    public void GoToCredits()
    {
        // LoadingScreen.Instance.Load("CreditsScene");
    }
}
