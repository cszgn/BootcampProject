using UnityEngine;

public class InputManagerEntry : MonoBehaviour
{
    private static InputManagerEntry _instance;

    public static InputManagerEntry GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<InputManagerEntry>();
            if (_instance == null)
            {
                GameObject obj = new GameObject("InputManagerEntry");
                _instance = obj.AddComponent<InputManagerEntry>();
            }
        }
        return _instance;
    }

    public bool GetInteractPressed()
    {
        // Örnek olarak "E" tu?una bas?m? kontrol edelim
        return Input.GetKeyDown(KeyCode.E);
    }
}