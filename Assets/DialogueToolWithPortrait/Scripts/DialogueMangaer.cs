using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueMangaer : MonoBehaviour
{
    // allows text speed to be changed by user
    [SerializeField] public float textSpeed;

    //text elements
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    //animator for text box motion (optional) 
    public Animator animator;

    //holds sentences
    private Queue<string> sentences;

    void Start()
    {
        //loads first sentence
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); //makes sure animator starts with box off-screen
        Debug.Log("Starting converstation with " + dialogue.name);//shows dialogue start in the console

        //shows name
        nameText.text = dialogue.name;

        //makes sure previous sentences are cleared before starting
        sentences.Clear();

        //types out sentences
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
 
    public void DisplayNextSentence() //allows the next sentence to display based on a trigger
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)// types each letter of the sentence in an animation
    {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void EndDialogue() //stops dialogue and closes text box
    {
        animator.SetBool("IsOpen", false);
    }
}
