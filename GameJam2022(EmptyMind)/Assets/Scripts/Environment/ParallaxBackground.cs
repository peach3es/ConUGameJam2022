using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxEffectX;
    public float parallaxEffectY;
    public GameObject cam;
    private float length, startPos;


    private void Start() {
        startPos = transform.position.x;
        startPos = transform.position.y;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() {
        float temp = (cam.transform.position.x * (1 - parallaxEffectX));
        float distx = (cam.transform.position.x * parallaxEffectX);
        float disty = (cam.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startPos + distx, transform.position.y, transform.position.z);

        if (temp > startPos + length) {
            startPos += length;
        } else if (temp < startPos - length) {
            startPos -= length;
        }
    }
}
