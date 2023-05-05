using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Puzzle : MonoBehaviour
{
    [SerializeField] List<Transform> doors;
    [SerializeField] List<Button> buttons;
    bool isRotating = false;
    IEnumerator RotateDoorCoroutine(int doorIndex)
    {
        isRotating = true;
        Quaternion startRotate = doors[doorIndex].transform.rotation;
        Quaternion endRotate = doors[doorIndex].transform.rotation * Quaternion.Euler(0,180,0);
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime * 1;
            doors[doorIndex].transform.rotation = Quaternion.Lerp(startRotate,endRotate,i);
            yield return null;
        }
        enableButtons(buttons);
    }
    void disableButtons(List<Button> buttons)
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
    }
    void enableButtons(List<Button> buttons)
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }
    }
    public void StartRotate(int doorIndex)
    {
        StartCoroutine(RotateDoorCoroutine(doorIndex));
    }
    public void Button1Pressed()
    {   
        disableButtons(buttons); 
        StartRotate(0); 
        StartRotate(1);
    }
    public void Button2Pressed()
    {
        disableButtons(buttons); 
        StartRotate(0); 
        StartRotate(1);
        StartRotate(2);
    }
    public void Button3Pressed()
    {
        disableButtons(buttons); 
        StartRotate(1); 
        StartRotate(2);
        StartRotate(3);
    }
    public void Button4Pressed()
    {
        disableButtons(buttons); 
        StartRotate(2); 
        StartRotate(3);
    }
}

