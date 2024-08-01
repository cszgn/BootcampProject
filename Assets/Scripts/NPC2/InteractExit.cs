using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractExit : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<TargetNPC2>().enabled = true;
        transform.parent.GetComponent<TargetNPC2>().AgentContiue();
    }
}

