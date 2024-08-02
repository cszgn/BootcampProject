using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // D��menin Animator bile�enini al�yoruz
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter()
    {
        Debug.Log("Mouse entered button");
        animator.SetTrigger("Highlighted");
    }

    public void OnPointerExit()
    {
        Debug.Log("Mouse exited button");
        animator.SetTrigger("Normal");
    }


    public void OnButtonPressed()
    {
        // D��meye bas�ld���nda tetiklenecek metod
        animator.SetTrigger("Pressed");
    }

    public void OnButtonDisabled()
    {
        // D��me devre d��� b�rak�ld���nda tetiklenecek metod
        animator.SetTrigger("Disabled");
    }
}