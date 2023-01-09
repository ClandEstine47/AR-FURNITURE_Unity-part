using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private PointerEventData pData;
    private EventSystem eventSystem;
    public Transform selectionPoint;
    [SerializeField]
    public Button backBtn;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);

        pData.position = selectionPoint.position;

        backBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
