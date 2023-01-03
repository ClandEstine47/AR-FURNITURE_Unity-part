using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1;
        //print("Child count" + childCount);
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        //print("childwidth" + childWidth);
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left;
        //print("width"+ width);
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
