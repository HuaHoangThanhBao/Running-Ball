using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;

    public Variables variables;

    EdgeControl edgeControl;
    ScoreHandle scoreHandle;

    private void Awake()
    {
        scoreHandle = FindObjectOfType<ScoreHandle>();
        edgeControl = FindObjectOfType<EdgeControl>();
        rb = GetComponent<Rigidbody>();
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, variables.rangeDown, variables.layerMask); //Kiểm tra xem player có chạm đất ko?
    }

    void Inputs()
    {
        if(Input.GetMouseButton(0))
        {
            variables.gameBegin = true; //Bắt đầu game
        }
    }

    private void Update()
    {
        if (!variables.hitSpike)
        {
            Inputs();
            CheckForFall();
            CheckForTrigger();
            MoveTowardMousePosition();
        }
    }

    private void LateUpdate()
    {
        Movement();
    }

    void MoveTowardMousePosition()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) //Nhận biết đang chạy trên nền tảng nào
        {
            if (Input.touchCount > 0) //Nếu player chạm vào màn hình android
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {

                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                    transform.position = Vector3.Lerp(transform.position, new Vector3(touchedPos.x, transform.position.y, transform.position.z), Time.deltaTime * variables.lerpSpeed);
                }
            }
        }
        else // dành cho pc
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                transform.position = Vector3.Lerp(transform.position, new Vector3(mouse.x, transform.position.y, transform.position.z), Time.deltaTime * variables.lerpSpeed);
            }
        }
    }

    void Movement()
    {
        if (variables.gameBegin)
        {
            if (isGrounded())
            {
                if (variables.numberHit == 0)//Đếm số lần chạm đất
                {
                    variables.numberOfHitGround++;
                    variables.numberHit++;
                }

                rb.velocity = Vector3.up * variables.jumpForce;

                Physics.gravity = new Vector3(0, -variables.baseGravity, 0); //Apply vectơ gia tốc trọng trường cho vật thể
            }
            else variables.numberHit = 0;
        }
    }

    void CheckForTrigger()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.forward, out hit, variables.rangeForward, variables.layerMask)) //Thực hiện raycast về phía trước
        {
            if (hit.transform.tag == "Trigger") //Nếu thấy đối tượng trigger thì sẽ add 1 vecto gia tốc kéo vật đi xuống
            {
                timeFall = 0;

                foreach (GameObject name in edgeControl.edgeCloneList)
                {
                    GameObject go = GameObject.Find(hit.transform.name); //Tạo gameobject tạm với tên khai báo là khi raycst tìm thấy trigger

                    if (go) // Nếu tìm thấy vật thể trong danh sách gameobject thì xóa nó đi
                    {
                        variables.hitTrigger = true;

                        Destroy(go.gameObject);

                        Physics.gravity = new Vector3(0, -variables.gravityScale, 0);
                    }
                }
            }
            else variables.hitTrigger = false;
        }
    }

    float timeFall;

    void CheckForFall()
    {
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 5f, variables.layerMask)) //Thực hiện raycast xuống, nếu ko tìm thấy thì apply lực kéo
        {
            timeFall += Time.deltaTime;

            if (timeFall > 0.5f)
            {
                variables.endGame = true;
            }

            Physics.gravity = new Vector3(0, -variables.gravityScale, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Circle")
        {
            Destroy(other.gameObject);

            scoreHandle.IncreaseScore();
        }
    }
}
