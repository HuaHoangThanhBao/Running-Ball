using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollisionAction : MonoBehaviour {

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Spike") player.variables.hitSpike = true;
    }
}
