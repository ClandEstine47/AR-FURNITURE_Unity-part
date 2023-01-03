using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private RawImage buttonImage;

    private int itemId; 
    private Sprite buttonTexture;
    public Sprite ButtonTexture
    {
        set
        {
            buttonTexture = value;
            buttonImage.texture = buttonTexture.texture;
        }
    }

    public int ItemId
    {
        set
        {
            itemId = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.3f);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            //transform.localScale = Vector3.one; 
        }
    }

    void SelectObject()
    {
        // DataHandler.Instance.furniture = furniture;
        DataHandler.Instance.SetFurniture(itemId);
    }
}
