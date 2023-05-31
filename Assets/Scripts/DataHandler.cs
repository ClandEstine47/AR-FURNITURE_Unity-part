using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.AddressableAssets;
//using System.Threading.Tasks;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    [SerializeField]
    private ButtonManager buttonPrefab;
    [SerializeField]
    private GameObject buttonContainer;
    [SerializeField]
    private List<Item> items;
    public Text textElement;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public string ReceivedMessagFromAndroid;
    //[SerializeField]
    // private string label;

    private int curretn_id = 0;
=======
    public string ReceivedMessageFromAndroid;
>>>>>>> Mausam
=======
    public string ReceivedMessageFromAndroid;
>>>>>>> Mausam
=======
    public string ReceivedMessageFromAndroid;
>>>>>>> Mausam

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        LoadItems();
        // await Get(label);
        CreateButton();
=======
        //LoadItems(ReceivedMessageFromAndroid);
>>>>>>> Mausam
=======
        //LoadItems(ReceivedMessageFromAndroid);
>>>>>>> Mausam
=======
        //LoadItems(ReceivedMessageFromAndroid);
>>>>>>> Mausam
    }

    void LoadItems(string ObjLocation)
    {
        var items_obj = Resources.LoadAll("Items/" + ObjLocation, typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
    }


    void CreateButton()
    {
        foreach (Item i in items)
        {
            ButtonManager bm = Instantiate(buttonPrefab, buttonContainer.transform);
            bm.ItemId = curretn_id;
            bm.ButtonTexture = i.itemImage;
            curretn_id++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    /*  public async Task Get(string label)
      {
          var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
          foreach(var location in locations)
          {
              var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
              items.Add(obj);
          }
      }
    */
}
