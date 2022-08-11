using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveScale : MonoBehaviour
{
    private CanvasScaler canvasScale;
    // Start is called before the first frame update
    void Start()
    {
        canvasScale = GetComponent<CanvasScaler>();
        canvasScale.referenceResolution = new Vector2(Display.main.systemWidth, Display.main.systemHeight);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
