using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCloneControl : MonoBehaviour {

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        if(player.variables.gameBegin && !player.variables.hitSpike && !player.variables.endGame)
        {
            this.transform.Translate((Vector3.down / player.variables.downRange + Vector3.back / player.variables.backRange) * Time.deltaTime * player.variables.speed); // Di chuyển khối vật thể bao gồm những những con của nó
        }
    }
}
