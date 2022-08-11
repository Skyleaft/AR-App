using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatchItem : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerUpHandler
{
    static MatchItem hoverItem;

    public GameObject linePrefabs;
    public string itemName;
    private GameObject line;
    public Transform parent;
    public Animator anim;
    public AudioSource sound;
    public AudioClip failSound;

    public void OnDrag(PointerEventData eventData)
    {
        UpdateLine(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        line = Instantiate(linePrefabs,transform.position,Quaternion.identity, parent);
        UpdateLine(eventData.position);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverItem = this;
        Debug.Log("Current hover :"+hoverItem.itemName);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!this.Equals(hoverItem) && itemName.Equals(hoverItem.itemName))
        {
            UpdateLine(hoverItem.transform.position);
            //MatchLogic.AddPoint();
            anim.SetTrigger("success");
            Destroy(hoverItem);
            Destroy(this);
        }
        else if (!itemName.Equals(hoverItem.itemName))
        {
            anim.SetTrigger("fail");
            sound.Stop();
            sound.PlayOneShot(failSound);
            Destroy(line);
        }
        else
        {
            
            Destroy(line);
        }
    }


    void UpdateLine(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        line.transform.right = direction;
        //Debug.Log(direction.magnitude);

        //update scale
        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }

}
