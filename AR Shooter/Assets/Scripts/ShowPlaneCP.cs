using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

using TMPro;

public class ShowPlaneCP : MonoBehaviour
{
    [SerializeField] GameObject arSessionOrigin;
    [SerializeField] GameObject player;

    public float distanceBetweenPlaneCenterAndPlayer;
    public Vector3 planeCenter;


    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var planes = "";

        // planes += arSessionOrigin.GetComponent<ARPlaneManager>().trackables.count;

        foreach (var plane in arSessionOrigin.GetComponent<ARPlaneManager>().trackables)
        {
            distanceBetweenPlaneCenterAndPlayer = Vector3.Distance(player.transform.position, plane.center);
            planeCenter = plane.center;
            // planes += plane.center + "\n" + distanceBetweenPlaneCenterAndPlayer;
            planes += distanceBetweenPlaneCenterAndPlayer + "\n";

        }

        // text.text = FindObjectOfType<TestLocationService>().location;
        text.text = planes;
        // text.text = arSessionOrigin.GetComponent<ARPlaneManager>().planePrefab.GetComponent<ARPlane>().center.ToString();
    }
}
