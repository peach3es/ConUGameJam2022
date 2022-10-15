using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform followTransform;
    public float height_y = 13.61f;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;



    void LateUpdate()
    {
        Vector3 newPosition = followTransform.position;

        if (followTransform.position.y <= lowerBound)
        {
            newPosition.y = lowerBound;
        }
       
        if (followTransform.position.y >= upperBound)
        {
            newPosition.y = upperBound;
        }

        if (followTransform.position.x <= leftBound)
        {
            newPosition.x = leftBound;
        }

        if (followTransform.position.x >= rightBound)
        {
            newPosition.x = rightBound;
        }

        this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
    }

   // followTransform.position.y

}



/*
public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, this.transform.position.z);
    }
}
*/

