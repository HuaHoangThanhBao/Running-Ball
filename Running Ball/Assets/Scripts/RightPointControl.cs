using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPointControl : MonoBehaviour {

    GameObject point;

    Player player;

    private void Awake()
    {
        point = Resources.Load("Prefabs/Point Left") as GameObject;

        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            point = (GameObject)Instantiate(point, new Vector3(0.8f, player.variables.yAxis_R, player.variables.zAxis_R), Quaternion.identity);
            point.transform.parent = transform;

            player.variables.yAxis_R += 0.5f;
            player.variables.zAxis_R += 1;
        }
    }

    public void CreateRightPoint()
    {
        point = (GameObject)Instantiate(point, new Vector3(0.8f, transform.GetChild(5).transform.position.y + 0.5f, transform.GetChild(5).transform.position.z + 1), Quaternion.identity);
        point.transform.parent = transform;
        Destroy(transform.GetChild(0).gameObject);
    }
}
