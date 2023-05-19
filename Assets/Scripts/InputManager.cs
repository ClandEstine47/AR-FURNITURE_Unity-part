using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class InputManager : ARBaseGestureInteractable
{
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    [SerializeField]
    private GameObject crosshair;
    private Pose pose;
    public List<GameObject> furnitures = new List<GameObject>();
    [SerializeField]
    public Button deleteBtn;
    [SerializeField]
    public Button placeFurnitureBtn;
    [SerializeField]
    public Button backBtn;
    [SerializeField]
    public Button ScreenshotBtn;

    public GameObject UI;
    public GameObject CrossHair;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaceFurnitures()
    {
        GameObject placedObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
        furnitures.Add(placedObj);
        var anchorObject = new GameObject("PlacementAnchor");
        anchorObject.transform.position = pose.position;
        anchorObject.transform.rotation = pose.rotation;
        placedObj.transform.parent = anchorObject.transform;
    }

    public void DeleteFurnitures()
    {
        for(int i = furnitures.Count-1; i>=0; i--)
        {
            Destroy(furnitures[i]);
            if (furnitures[i])
            {
                furnitures.Remove(furnitures[i]);
            }
        }
    }

    public void QuitUnity()
    {
        Application.Quit();
    }

    public void TakeScreenshot()
    {
        UI.SetActive(false);
        CrossHair.SetActive(false);
        StartCoroutine("Screenshot");
    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot_ARFurniture" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        NativeGallery.SaveImageToGallery(texture, "AR Furniture", name);

        Destroy(texture);
        UI.SetActive(true);
        CrossHair.SetActive(true);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        CrosshairCalculation();
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        if (GestureTransformationUtility.Raycast(origin, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}



