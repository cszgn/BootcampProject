using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemNotification itemNotification; // ItemNotification script'ini referans al

    private void OnTriggerEnter(Collider other)
    {
        // Diðer objenin bir CollectibleItem olup olmadýðýný kontrol et
        CollectibleItem collectibleItem = other.GetComponent<CollectibleItem>();

        if (collectibleItem != null)
        {
            // ItemNotification script'inde ShowNotification metodunu çaðýr
            if (itemNotification != null)
            {
                itemNotification.ShowNotification(collectibleItem);
            }

            // Eþyayý toplama iþlemlerini buraya ekleyin
            Destroy(other.gameObject); // Eþyayý sahneden kaldýr
        }
    }
}
