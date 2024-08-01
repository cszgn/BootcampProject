using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCChoice : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject thePlayer;


    void Update()
    {
        //TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Talk";
            ActionText.SetActive(true);
        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                this.transform.LookAt(new Vector3(thePlayer.transform.position.x, this.transform.position.y,thePlayer.transform.position.z));
                this.GetComponent<Animator>().Play("Idle");
                this.GetComponent<NavMeshAgent>().enabled = false;
                this.GetComponent<NPCAINav>().enabled = false;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Hello there, how can I help you?";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ResetChat());
                
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false) ;
    }

    IEnumerator ResetChat()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<Animator>().Play("Idle");
        this.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<NPCAINav>().enabled = true;
    }
}


