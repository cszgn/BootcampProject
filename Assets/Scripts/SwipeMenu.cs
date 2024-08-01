using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public Button selectButton;
    public ScrollRect scrollRect;
    public string winSceneName = "WinScene";
    public string loseSceneName = "LoseScene";

    public Color selectedColor = new Color(1f, 1f, 0f, 1f);
    public Color defaultColor = Color.white;

    public Vector2 selectedOutlineSize = new Vector2(5f, 5f);
    public Vector2 defaultOutlineSize = new Vector2(2f, 2f);

    private float[] pos;
    private RectTransform contentRect;

    void Start()
    {

        if (selectButton != null)
        {
            selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        else
        {
            Debug.LogError("Select Button has not been assigned.");
        }


        if (scrollRect == null)
        {
            Debug.LogError("ScrollRect has not been assigned.");
        }
        else
        {
            contentRect = scrollRect.content;
            InitializePositions();
            AddOutlineToChildren();
        }
    }

    void Update()
    {

        float scrollPos = scrollRect.horizontalNormalizedPosition;

        UpdateItemScale(scrollPos);
        UpdateItemOutline(scrollPos);
    }

    void InitializePositions()
    {
        int itemCount = contentRect.childCount;
        pos = new float[itemCount];
        float distance = 1f / (itemCount - 1f);
        for (int i = 0; i < itemCount; i++)
        {
            pos[i] = distance * i;
        }
    }
    void UpdateItemScale(float scrollPos)
    {
        int itemCount = contentRect.childCount;
        float distance = 1f / (itemCount - 1f);

        for (int i = 0; i < itemCount; i++)
        {
            Transform child = contentRect.GetChild(i);
            Text text = child.GetComponentInChildren<Text>();

            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(1f, 1f, 1f), 0.1f);

                if (text != null)
                {
                    text.gameObject.SetActive(true);
                }
            }
            else
            {
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(0.8f, 0.8f, 1f), 0.1f);

                if (text != null)
                {
                    text.gameObject.SetActive(false);
                }
            }
        }
    }

    void UpdateItemOutline(float scrollPos)
    {
        int itemCount = contentRect.childCount;
        float distance = 1f / (itemCount - 1f);

        for (int i = 0; i < itemCount; i++)
        {
            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {
                SetOutlineColor(contentRect.GetChild(i), selectedColor, selectedOutlineSize);
            }
            else
            {
                SetOutlineColor(contentRect.GetChild(i), defaultColor, defaultOutlineSize);
            }
        }
    }

    void SetOutlineColor(Transform child, Color color, Vector2 outlineSize)
    {
        Outline outline = child.GetComponent<Outline>();
        if (outline == null)
        {
            outline = child.gameObject.AddComponent<Outline>();
        }
        outline.effectColor = color;
        outline.effectDistance = outlineSize;
    }

    void AddOutlineToChildren()
    {
        foreach (Transform child in contentRect)
        {
            SetOutlineColor(child, defaultColor, defaultOutlineSize);
        }
    }

    private void OnSelectButtonClick()
    {
        foreach (Transform child in contentRect)
        {
            Image image = child.GetComponent<Image>();
            if (image != null && child.localScale == new Vector3(1f, 1f, 1f))
            {
                if (image.CompareTag("Right"))
                {
                   
                    SceneManager.LoadScene(winSceneName);
                }
                else if (image.CompareTag("Wrong"))
                {
                    
                    SceneManager.LoadScene(loseSceneName);
                }
                return; 
            }
        }
        
        Debug.LogWarning("No image with 'Right' or 'Wrong' tag found.");
    }
}