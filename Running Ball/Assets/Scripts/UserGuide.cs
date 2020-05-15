using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGuide : MonoBehaviour {

    Vector3 left;
    Vector3 right;

    private void Start()
    {
        left = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        right = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
    }

    void Update () {
        float time = Mathf.PingPong(Time.time * 1.2f, 1);
        transform.position = Vector3.Lerp(left, right, time);
    }
}
