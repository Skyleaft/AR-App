using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurufManager : MonoBehaviour
{
    public List<ObjekHurufScriptable> hurufList;
    public List<ObjectSettings> TargetObject;
    public DragDropManager dragDropManager;
    public Image targetImage;

    private PanelSettings _panel;
    private int targetNum;
    private int targetSegment;

    private CurrentObject current;

    List<int> usedValues = new List<int>();

    void Start()
    {
        _panel = dragDropManager.AllPanels[0];
        current = GameObject.FindGameObjectWithTag("Current").GetComponent<CurrentObject>();
        generateRandom();
    }

    public void generateRandom()
    {
        targetSegment = Random.Range(1,4);
        Debug.Log(targetSegment);
        if (targetSegment == 1)
        {
            targetNum = Random.Range(0, 3);
            _panel.Id = hurufList[targetNum].nama;
            current.setObject(hurufList[targetNum]);
            targetImage.sprite = hurufList[targetNum].image;
            foreach(ObjectSettings obj in TargetObject)
            {
                int uniq = UniqueRandomInt(0, 3);
                obj.Id = hurufList[uniq].nama;
                obj.AllowedPanels[0] = hurufList[uniq].nama;
            }
            usedValues.Clear();

        }
        else if (targetSegment == 2)
        {
            targetNum = Random.Range(3, 6);
            _panel.Id = hurufList[targetNum].nama;
            current.setObject(hurufList[targetNum]);
            targetImage.sprite = hurufList[targetNum].image;
            foreach (ObjectSettings obj in TargetObject)
            {
                int uniq = UniqueRandomInt(3, 6);
                obj.Id = hurufList[uniq].nama;
                obj.AllowedPanels[0] = hurufList[uniq].nama;
            }
            usedValues.Clear();

        }
        else if (targetSegment == 3)
        {
            targetNum = Random.Range(6, 9);
            _panel.Id = hurufList[targetNum].nama;
            current.setObject(hurufList[targetNum]);
            targetImage.sprite = hurufList[targetNum].image;
            foreach (ObjectSettings obj in TargetObject)
            {
                int uniq = UniqueRandomInt(6, 9);
                obj.Id = hurufList[uniq].nama;
                obj.AllowedPanels[0] = hurufList[uniq].nama;
            }
            usedValues.Clear();
        }
    }

    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        usedValues.Add(val);
        return val;
    }




}
