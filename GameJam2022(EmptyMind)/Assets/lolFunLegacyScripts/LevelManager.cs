using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject player;

    [SerializeField] Camera cam;
    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        GameObject rebornPlayer = Instantiate(player, respawnPoint.position, Quaternion.identity);
        

    }
}
