using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMoveAction : MonoBehaviour {

    bool lerpingLeft;
    bool lerpingRight;

    Transform a;
    Transform b;

    int randomTranform;

    private void Update()
    {
        if(lerpingLeft && a != null && b != null)
        {
            float time = Mathf.PingPong(Time.time * 1.5f, 1);
            transform.position = Vector3.Lerp(a.position, b.position, time);
        }

        if(lerpingRight && a != null && b!= null)
        {
            float time = Mathf.PingPong(Time.time * 1.5f, 1);
            transform.position = Vector3.Lerp(b.position, a.position, time);
        }
    }

    public void Lerping(Transform start, Transform end)
    {
        if (start != null && end != null)
        {
            a = start;
            b = end;

            randomTranform = Random.Range(1, 10);

            switch(randomTranform)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    lerpingLeft = true;
                    break;

                case 2:
                case 4:
                case 6:
                case 8:
                case 10:
                    lerpingRight = true;
                    break;
            }
        }
    }
}
