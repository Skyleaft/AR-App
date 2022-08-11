using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchLogic : MonoBehaviour
{
    static MatchLogic instance;

    public int maxPoint = 3;
    public Text PointText;
    public GameObject levelCompleteGUI;

    private int points;

    private void Start()
    {
        instance = this;
    }

    public static void AddPoint()
    {
        AddPoints(1);
    }

    public static void AddPoints(int _points)
    {
        instance.points += _points;
        
    }
}
