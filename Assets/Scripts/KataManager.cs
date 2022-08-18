using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KataManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> katas;
    [SerializeField] private List<PanelSettings> kataSets;

    public Animator messageSucces;

    public bool p1;
    public bool p2;
    void Start()
    {
        
    }

    public void setBenar1()
    {
        p1 = true;
    }
    public void setBenar2()
    {
        p2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(p1 && p2)
        {
            StartCoroutine(berhasil());
        }
    }

    IEnumerator berhasil()
    {
        yield return new WaitForSeconds(1);
        messageSucces.SetTrigger("success");
    }
}
