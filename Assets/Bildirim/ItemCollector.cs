using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemNotification itemNotification; // ItemNotification script'ini referans al

    private void OnTriggerEnter(Collider other)
    {
        // Di�er objenin bir CollectibleItem olup olmad���n� kontrol et
        CollectibleItem collectibleItem = other.GetComponent<CollectibleItem>();

        if (collectibleItem != null)
        {
            // ItemNotification script'inde ShowNotification metodunu �a��r
            if (itemNotification != null)
            {
                itemNotification.ShowNotification(collectibleItem);
            }

            // E�yay� toplama i�lemlerini buraya ekleyin
            Destroy(other.gameObject); // E�yay� sahneden kald�r
        }
    }
}
