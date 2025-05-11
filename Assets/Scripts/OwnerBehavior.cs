using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OwnerBehavior : MonoBehaviour
{
    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public List<string> lines = new List<string>();
    private int index;

    private float typingSpeed = 0.02f;

    private Coroutine typingCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        //lines.AddRange(new List<string> {"Hey, you're the new hire right?", "Listen, today is going to be a busy day.", "So I need you to accept anyone that enters the building, okay?"});
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(){
        dialogueContainer.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if (typingCoroutine != null){
            StopCoroutine(typingCoroutine);
        }
        if (index == lines.Count){
            EndDialogue();
            return;
        }

    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue(){
        dialogueContainer.SetActive(false);
    }


}
