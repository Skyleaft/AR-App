using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI mainText;
    private ObjectSettings objectName;
    void Start()
    {
        objectName = GetComponent<ObjectSettings>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainText.text = objectName.Id;
    }
}
