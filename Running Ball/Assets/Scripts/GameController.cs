using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    GameObject bar;
    GameObject userGuide;
    GameObject background;

    private void Awake()
    {
        bar = (GameObject)Instantiate(Resources.Load("Prefabs/Bar") as GameObject, new Vector3(0, 0.5f, 2.48f), Quaternion.identity);
        userGuide = (GameObject) Instantiate(Resources.Load("Prefabs/User Guide") as GameObject, new Vector3(0.1f, 0.6f, 2.2f), Quaternion.identity);
        background = (GameObject)Instantiate(Resources.Load("Prefabs/Background") as GameObject, new Vector3(0, 0, 20f), Quaternion.identity);
    }

    void Start () {
        bar.transform.localScale = new Vector3(0.25f, 0.28f, 0.25f);
        bar.transform.parent = GameObject.FindGameObjectWithTag("GameController").transform;
        userGuide.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
        userGuide.transform.parent = GameObject.FindGameObjectWithTag("GameController").transform;
        background.transform.localScale = new Vector3(50, 50, 1);
        background.transform.parent = GameObject.FindGameObjectWithTag("GameController").transform;
    }
}
