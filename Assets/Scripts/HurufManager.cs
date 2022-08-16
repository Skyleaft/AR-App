using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurufManager : MonoBehaviour
{
    public List<ObjekHuruf> hurufList;
    public DragDropManager dragDropManager;
    public Image targetImage;

    private PanelSettings _panel;
    private ObjectSettings _objectSettings;
    private int targetNum;
    void Awake()
    {
        targetNum = Random.Range(0,8);
        _panel = dragDropManager.AllPanels[0];
        generateRandom();


    }

    void Update()
    {
        
    }

    public void generateRandom()
    {
        targetNum = Random.Range(0, 8);
        GetKelipatan3(targetNum);
        _panel.Id = hurufList[targetNum].nama;
        targetImage.sprite = hurufList[targetNum].image;
        int randomNum = Random.Range(0, 3);
        dragDropManager.AllObjects[randomNum].Id = hurufList[targetNum].nama;
        dragDropManager.AllObjects[randomNum].AllowedPanels[0] = hurufList[targetNum].nama;
    }

    public void GetKelipatan3(int _number)
    {
        if (_number % 3 == 0 && _number % 5 == 0)
        {
            Debug.Log(_number + " FizzBuzz");
        }
        else if (_number % 3 == 0)
        {
            Debug.Log(_number + " Fizz");
        }
        else if (_number % 5 == 0)
        {
            Debug.Log(_number + " Buzz");
        }
        else
        {
            Debug.Log(_number);
        }
    }

}
