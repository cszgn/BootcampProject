using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
       
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);       
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (GetComponent<Collider>().gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}