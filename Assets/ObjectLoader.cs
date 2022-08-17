using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectLoader : MonoBehaviour
{
    public TextMeshProUGUI judul;

    private CurrentObject current;
    void Awake()
    {
        current = GameObject.FindGameObjectWithTag("Current").GetComponent<CurrentObject>();
        judul.text = current.currentObject.nama;
        Instantiate(current.currentObject.objek, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
