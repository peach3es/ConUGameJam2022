using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 5f;
    public Transform target;
    public float xOffSet = 1f;
    public float yOffSet = 1f;

    public float yMax;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffSet, target.position.y + yOffSet, -10f);

        if (newPos.y > yMax)
        {
            newPos.y = yMax;
        }

        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
