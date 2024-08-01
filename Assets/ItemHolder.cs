using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        GameObject currentItem = GameObject.FindWithTag("item");  // Etiketi "Item" olan nesneyi bul

        if (currentItem != null)
        {
            if(currentItem.name == "Torch")
            {
                _anim.SetBool("HaveTorch", true);
            }
        }
        else
        {
            Debug.Log("ItemHolder'da item bulunmuyor.");
        }
    }
}

