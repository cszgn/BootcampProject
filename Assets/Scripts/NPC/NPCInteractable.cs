using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _interactText;

    [SerializeField] private string _textforNPC;

    Animator _anim;
    

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    
    }
    internal void Interact()
    {
        _interactText.text = "Hello ";

        _anim.SetTrigger("Talking");
        
    }

    public string GetIntereactText()
    {
        return _textforNPC;
    }

    public Transform GetTransform()
    {
        return _anim.transform;
    }

}
