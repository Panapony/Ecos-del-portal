using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{
    
[SerializeField] private GameObject dialogueMark;
[SerializeField, TextArea(4,6)] private string[] dialogueLines;
 [SerializeField] private TMP_Text dialogueText;
 [SerializeField] private GameObject dialoguePanel;
 private bool isPlayerInRange;

private float typingTime =0.05f;
 private bool didDialogueStart;
 private int lineIndex;

 
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(!didDialogueStart)
            {
                StartDialogue(); 
            }
           else if (dialogueText.text == dialogueLines[lineIndex])
           {
            NextDialogueLine();
           }
           else{
         StopAllCoroutines();
         dialogueText.text= dialogueLines[lineIndex];
           }
        }
    }

private void StartDialogue()
{
didDialogueStart=true;
dialoguePanel.SetActive(true);
dialogueMark.SetActive(false);
lineIndex=0;
Time.timeScale=0f;
StartCoroutine(showLine());
}

private void NextDialogueLine()
{
    lineIndex++;
    if(lineIndex < dialogueLines.Length)
    {
        StartCoroutine(showLine());
    }
    else{
        didDialogueStart=false;
        dialoguePanel.SetActive(false);
        dialogueMark.SetActive(true);
        Time.timeScale=1f;
    }
}

private IEnumerator showLine()
{
    dialogueText.text=string.Empty;

    foreach(char ch in dialogueLines[lineIndex])
    {
        dialogueText.text += ch;
        yield return new WaitForSecondsRealtime(typingTime);
    }
}

    

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.gameObject.CompareTag("Player"))
    {
     isPlayerInRange=true;  
      dialogueMark.SetActive(true);
     
    }
        

    }
private void OnTriggerExit2D(Collider2D colision)
{

    if(colision.gameObject.CompareTag("Player"))
    {
    isPlayerInRange= false;  
    dialogueMark.SetActive(false);  
   
    }
    
}

}
