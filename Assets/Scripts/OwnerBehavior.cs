using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OwnerBehavior : MonoBehaviour
{
    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    //public GameObject readyButton;
    //public Button button;
    //public Menu menu;
    public GameObject floorOwner;
    public GameObject floorSlime;
    public bool speaking = false;
    public List<string> lines = new List<string>();
    private int index;

    private float typingSpeed = 0.03f;

    private Coroutine typingCoroutine;
    private Coroutine speechCoroutine;
    
    public AudioSource gameAudio;
    //public AudioClip backgroundAudio;
    public AudioClip textAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        //lines.AddRange(new List<string> {"Hey, you're the new hire right?", "Listen, today is going to be a busy day.", "So I need you to accept anyone that enters the building, okay?"});
        index = 0;
        dialogueContainer.SetActive(false);
        gameAudio = GetComponent<AudioSource>();
        //readyButton.SetActive(false);
        //button.onClick.AddListener(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && dialogueContainer.activeInHierarchy){
            DisplayNextLine();
        }
    }

    public void StartDialogue(){
        dialogueContainer.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if (typingCoroutine != null){
            StopCoroutine(typingCoroutine);
            StopCoroutine(speechCoroutine);
            speaking = false;
        }
        if (index == lines.Count){
            EndDialogue();
            return;
        }

        typingCoroutine = StartCoroutine(TypeText(lines[index]));
        speaking = true;
        speechCoroutine = StartCoroutine(TextSound(speaking));
        index += 1;
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        StopCoroutine(speechCoroutine);
    }

    IEnumerator TextSound(bool talk){
        while (talk){
            gameAudio.PlayOneShot(textAudio, 1.0f);
            yield return new WaitForSeconds(0.09f);
        }
    }

    public void EndDialogue(){
        dialogueContainer.SetActive(false);
        floorOwner.SetActive(false);
        floorSlime.SetActive(true);
        //readyButton.SetActive(true);
        //menu.SalonTrans();
    }

    /*private void nextScene(){
        readyButton.SetActive(false);
        menu.SalonTrans();
    }*/

}
