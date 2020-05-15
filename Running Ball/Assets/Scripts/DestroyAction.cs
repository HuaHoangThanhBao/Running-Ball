using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour {

    Player player;

    GameObject particleSystem;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        particleSystem = Resources.Load("Prefabs/Death Effect") as GameObject;
    }

    int i = 0;

    private void FixedUpdate()
    {
        if (player.variables.hitSpike && !player.variables.endGame)
        {
            if (i == 0)
            {
                player.variables.gameBegin = false;

                player.variables.endGame = true;

                Instantiate(particleSystem, transform.GetChild(0).transform.position + new Vector3(0, 0.7f, 0), particleSystem.transform.rotation);

                Destroy(transform.GetChild(0).gameObject);

                i++;
            }
        }
    }
}
