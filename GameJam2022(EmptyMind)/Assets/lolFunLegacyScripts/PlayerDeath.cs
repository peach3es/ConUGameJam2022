using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D foreignObject)
    {
        Collider2D collider = foreignObject.gameObject.GetComponent(typeof(Collider2D)) as Collider2D;

        if (collider != null && collider.sharedMaterial.name == "spikes")
        {
            //Destroy(gameObject);
            //LevelManager.instance.Respawn();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
