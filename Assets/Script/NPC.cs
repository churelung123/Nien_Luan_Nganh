using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject Indicator;
    public float wordSpeed;
    private  bool playerIsClose;
    private GameObject playerObj = null;
    public GameObject Eyes;

    void Update()
    {
        FacePlayer();

        if(playerIsClose && Input.GetKeyDown(KeyCode.E))
        {   
            Indicator.SetActive(false);
            if(dialoguePanel.activeInHierarchy)
            {
                Invoke("zeroText",10);
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E) && (dialogueText.text.Length > dialogue[index].Length || dialogueText.text == dialogue[index]))
        {
            NextLine();
        }
    }


    public void FacePlayer()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj.transform.position.x < Eyes.transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(playerObj.transform.position.x > Eyes.transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 360f, 0f);
        }
        else if(playerObj.transform.position.x == Eyes.transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        Debug.Log(gameObject.transform.position);
    }


    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            Indicator.SetActive(true);
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            Indicator.SetActive(false);
            playerIsClose = false;
            zeroText();
        }
    }
}