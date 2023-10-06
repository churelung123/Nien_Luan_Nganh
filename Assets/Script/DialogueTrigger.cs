using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;
    public bool isTalk;
    private GameObject FaceDirection;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }    
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.EndDialogue();
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            isTalk = true;
            dialogueScript.StartDialogue();
            FaceDirection = GameObject.FindGameObjectWithTag("Player");
            
            if(FaceDirection.transform.position.x < transform.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if(!playerDetected || !dialogueScript.isStart)
        {
            isTalk = false;
        }
    }
}
