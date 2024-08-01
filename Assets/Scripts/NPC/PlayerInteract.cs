using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NPCInteractable interactable = GetNPCInteractable();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public NPCInteractable GetNPCInteractable()
    {
        List<NPCInteractable> interactableList = new List<NPCInteractable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                npcInteractable.Interact();
                interactableList.Add(npcInteractable);
                return npcInteractable;
            }
        }

        return null ;
    }
}
