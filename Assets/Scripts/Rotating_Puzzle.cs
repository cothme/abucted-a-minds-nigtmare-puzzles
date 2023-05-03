using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Rotating_Puzzle : MonoBehaviour
{
    int pointedNumber;
    int nodeID,limit;
    public Transform arrow;
    public Transform[] images;
    public Color defaultColor;
    public Color pointedColor;
    public float rotationSpeed; 
    public float rotationDelay;
    public void Start()
    {
        pointedNumber = 1;
        limit = images.Length;
        foreach(Transform image in images)
        {
            image.GetComponent<Image>().color = defaultColor;
        }
    }
    IEnumerator RotateArrow(float targetAngle)
    {
        // wait for the delay before starting to rotate the arrow
        yield return new WaitForSeconds(rotationDelay);

        // calculate the difference between the current angle and the target angle
        float currentAngle = arrow.rotation.eulerAngles.z;
        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        // rotate the arrow gradually over time
        while (Mathf.Abs(angleDifference) > 0.01f)
        {
            float rotationAmount = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            arrow.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
            currentAngle = arrow.rotation.eulerAngles.z;
            angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);
            yield return null;
        }
        foreach (Transform image in images)
        {
            if (image == images[pointedNumber - 1])
            {
                image.GetComponent<Image>().color = pointedColor;
            }
            else
            {
                image.GetComponent<Image>().color = defaultColor;
            }
        }
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
        Vector3 direction = images[pointedNumber - 1].position - arrow.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        StartCoroutine(RotateArrow(targetAngle));
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
        Vector3 direction = images[pointedNumber - 1].position - arrow.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
