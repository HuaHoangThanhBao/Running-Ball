using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeControl : MonoBehaviour {

    Player player;
    GameObject triggerEdge;
    EdgeColoring edgeColoring;

    GameObject edgeNormal;
    GameObject edgeClones;
    GameObject leftPointControl;
    GameObject rightPointControl;
    
    public List<GameObject> edgeTypeList;
    public List<GameObject> edgeCloneList;

    int order = 6;
    int i = 0;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        edgeColoring = FindObjectOfType<EdgeColoring>();

        LoadRescourcesOnAwake();
    }

    void LoadRescourcesOnAwake()
    {
        edgeNormal = Resources.Load("Prefabs/Edge Normal") as GameObject;

        edgeClones = GameObject.FindGameObjectWithTag("EdgeClones");
        leftPointControl = GameObject.FindGameObjectWithTag("LeftPointControl");
        rightPointControl = GameObject.FindGameObjectWithTag("RightPointControl");

        //Những edge có trigger
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge One Left") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge One Right") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Two Left") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Two Right") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Two Center") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Two Equal") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Three Left") as GameObject);
        edgeTypeList.Add(Resources.Load("Prefabs/Trigger Edge Three Right") as GameObject);
    }

    private void Start()
    {
        player.variables.createWhenStart = true;

        //Tạo 1 edge normal ko có trigger
        CreateNormalEdge();

        //Tạo ra 6 edge cơ bản lúc mới vào game
        for (int i = 0; i < 6; i++)
        {
            int random = Random.Range(1, 8);

            SmartInstantiateEdgeType(player.variables.createWhenStart, random);
        }
        player.variables.createWhenStart = false;
    }

    void CreateNormalEdge()
    {
        edgeNormal = Instantiate(edgeNormal, new Vector3(0, player.variables.startY + 0.5f, player.variables.startZ + 1), Quaternion.identity);
        player.variables.startY += 0.5f;
        player.variables.startZ += 1;
        edgeNormal.transform.parent = edgeClones.transform;
        edgeCloneList.Add(edgeNormal);
    }

    //Tự động sinh ra edge khi vật chạm đất lần thứ 2
    void AutoGenerate()
    {
        if (player.variables.gameBegin && !player.variables.hitSpike)
        {
            if (player.variables.numberOfHitGround > 1 && player.isGrounded())
            {
                int random = Random.Range(1, 8);

                SmartInstantiateEdgeType(player.variables.createWhenStart, random);
            }
            else i = 0;
        }
    }

    void SmartInstantiateEdgeType(bool createWhenStart, int random)
    {
        if (!createWhenStart)
        {
            //Khai báo 2 trục y z khi game chạy
            float yAxis = edgeClones.transform.GetChild(7).transform.position.y + 0.5f;
            float zAxis = edgeClones.transform.GetChild(7).transform.position.z + 1;

            switch (random)
            {
                case 1:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[0], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        triggerEdge.GetComponent<EdgeMoveAction>().Lerping(leftPointControl.transform.GetChild(6), rightPointControl.transform.GetChild(6));

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 2:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[1], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        triggerEdge.GetComponent<EdgeMoveAction>().Lerping(leftPointControl.transform.GetChild(6), rightPointControl.transform.GetChild(6));

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 3:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[2], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 4:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[3], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 5:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[4], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        triggerEdge.GetComponent<EdgeMoveAction>().Lerping(leftPointControl.transform.GetChild(6), rightPointControl.transform.GetChild(6));

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 6:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[5], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 7:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[6], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        triggerEdge.GetComponent<EdgeMoveAction>().Lerping(leftPointControl.transform.GetChild(6), rightPointControl.transform.GetChild(6));

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
                case 8:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[7], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.GetComponent<MeshRenderer>().material.color = edgeColoring.colorMaterialList[player.variables.order].color;

                        triggerEdge.transform.parent = edgeClones.transform;

                        FindObjectOfType<RightPointControl>().CreateRightPoint();

                        FindObjectOfType<LeftPointControl>().CreateLeftPoint();

                        Destroy(edgeClones.transform.GetChild(0).gameObject);

                        i++;
                    }
                    break;
            }
        }
        else
        {
            //Khai báo 2 trục y và z khi bắt đầu game
            float yAxis = player.variables.startY + 0.5f;
            float zAxis = player.variables.startZ + 1;

            switch (random)
            {
                case 1:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[0], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 2:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[1], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 3:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[2], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 4:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[3], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 5:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[4], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 6:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[5], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 7:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[6], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
                case 8:
                    if (i == 0)
                    {
                        triggerEdge = Instantiate(edgeTypeList[7], new Vector3(0, yAxis, zAxis), Quaternion.identity);

                        triggerEdge.transform.parent = edgeClones.transform;
                        edgeCloneList.Add(triggerEdge);

                        i++;
                    }
                    break;
            }


            //Cập nhật lại biến
            i = 0;
            player.variables.startY += 0.5f;
            player.variables.startZ += 1;
        }
    }

    private void FixedUpdate()
    {
        AutoGenerate();
    }
}
