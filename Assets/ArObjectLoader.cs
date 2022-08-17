using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation.Samples;

public class ArObjectLoader : MonoBehaviour
{
    public TextMeshProUGUI judul;
    public PlaceOnPlane arObj;

    private CurrentObject current;
    // Start is called before the first frame update
    void Awake()
    {
        current = GameObject.FindGameObjectWithTag("Current").GetComponent<CurrentObject>();
        judul.text = current.currentObject.nama;
        arObj.placedPrefab = current.currentObject.objek;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
