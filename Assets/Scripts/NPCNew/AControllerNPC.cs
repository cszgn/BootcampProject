using UnityEngine;

public class NPCA_Controller : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        animator.SetTrigger("Idle");
    }

    public void SetWalking()
    {
        animator.SetTrigger("Walk");
    }
}