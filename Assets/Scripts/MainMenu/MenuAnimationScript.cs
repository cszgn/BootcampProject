using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Düðmenin Animator bileþenini alýyoruz
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
        // Düðmeye basýldýðýnda tetiklenecek metod
        animator.SetTrigger("Pressed");
    }

    public void OnButtonDisabled()
    {
        // Düðme devre dýþý býrakýldýðýnda tetiklenecek metod
        animator.SetTrigger("Disabled");
    }
}