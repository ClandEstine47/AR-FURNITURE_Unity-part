using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    [SerializeField]
    private List<Item> items;
    public Text textElement;
    public string ReceivedMessageFromAndroid;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
    public void ReceivedMessage(string message)
    {
        Debug.Log("Received message: " + message);
        ReceivedMessageFromAndroid = message;
        textElement.text = message;
        LoadItems(ReceivedMessageFromAndroid);
    }

    public void Start()
    {
        //LoadItems(ReceivedMessageFromAndroid);
    }

    void LoadItems(string ObjLocation)
    {
        var items_obj = Resources.LoadAll("Items/" + ObjLocation, typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
    }

    public GameObject GetFurniture()
    {
        furniture = items[0].itemPrefab;
        return furniture;
    }
}
