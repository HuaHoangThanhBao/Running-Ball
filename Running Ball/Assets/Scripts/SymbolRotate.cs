using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolRotate : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime * 5);
    }
}
