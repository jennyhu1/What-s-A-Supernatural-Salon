using UnityEngine;
using UnityEngine.SceneManagement;
using Esper.Freeloader;


public class Menu : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject OwnerNPC;

    public void StartGame()
    {
        Debug.Log("StartGame button clicked!");
        if (titlePanel != null)
            titlePanel.SetActive(false);
        LoadingScreen.Instance.Load("PimpleRemove");
    }

    public void GoToCredits()
    {
        // LoadingScreen.Instance.Load("CreditsScene");
    }

    public void SalonTrans(){
        LoadingScreen.Instance.Load("Salon");
        OwnerNPC.SetActive(false);
    }
}
