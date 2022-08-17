using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentObject : MonoBehaviour
{
    public ObjekHurufScriptable currentObject;

    public void setObject(ObjekHurufScriptable _obj)
    {
        currentObject = _obj;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
