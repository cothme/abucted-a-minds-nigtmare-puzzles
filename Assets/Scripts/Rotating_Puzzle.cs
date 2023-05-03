using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rotating_Puzzle : MonoBehaviour
{
    int pointedNumber;
    int nodeID,limit;
    public void Start()
    {
        pointedNumber = 1;
        limit = 7;
    }
    public void Move_Three()
    {
        pointedNumber += 3;
        if(pointedNumber > limit)
        {
            pointedNumber = pointedNumber % limit;
            if (pointedNumber == 0) {
                pointedNumber = limit;
            }
        }
        Debug.Log(pointedNumber);
    }

    public void Move_Four()
    {
        pointedNumber += 4;
        if(pointedNumber > limit)
        {
            pointedNumber = pointedNumber % limit;
            if (pointedNumber == 0) {
                pointedNumber = limit;
            }
        }
        Debug.Log(pointedNumber);
    }
}
