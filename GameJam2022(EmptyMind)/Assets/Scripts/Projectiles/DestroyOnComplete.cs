using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnComplete : MonoBehaviour
{
    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, delay);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
