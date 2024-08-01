using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _interactImage;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI _interactText;

    private void Update()
    {
        if(playerInteract.GetNPCInteractable() != null)
        {
            Show(playerInteract.GetNPCInteractable());
        }
        else
        {
            Hide();
        }
    }

    private void Show(NPCInteractable npcInteractable)
    {
        _interactImage.SetActive(true);
        _interactText.text = npcInteractable.GetIntereactText();
    }

    private void Hide()
    {
        _interactImage.SetActive(false);
    }
}
