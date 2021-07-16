using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;

    bool conversationStarted = false;

    public TextMeshProUGUI DialogueText;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && conversationStarted == true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();

        conversationStarted = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

        Debug.Log("Convo started");
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            FindObjectOfType<BasicMovementScript>().setPlayerFrozen(false);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
        Debug.Log("Convo Typing");
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

    }
}
