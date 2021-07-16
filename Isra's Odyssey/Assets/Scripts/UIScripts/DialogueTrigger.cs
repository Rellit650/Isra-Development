using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<BasicMovementScript>().setPlayerFrozen(true);
        Destroy(gameObject);
    }

}
