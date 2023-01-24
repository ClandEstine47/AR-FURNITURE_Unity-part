using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.UI;

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



