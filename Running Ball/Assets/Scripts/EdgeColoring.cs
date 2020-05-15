using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeColoring : MonoBehaviour {

    Player player;
    EdgeControl edgeControl;
    ScoreHandle scoreHandle;
    
    public List<Material> colorMaterialList;
    
    int i = 0;
    float time;
    int temp = 0;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        scoreHandle = FindObjectOfType<ScoreHandle>();
        edgeControl = FindObjectOfType<EdgeControl>();

        LoadResourcesOnAwake();
    }

    void LoadResourcesOnAwake()
    {
        for (int i = 0; i < 11; i++)
        {
            if(i == 0)
            {
                var path = "Materials/Edge";
                colorMaterialList.Add(Resources.Load<Material>(path));
            }
            else
            {
                var path = "Materials/Color Change Materials/" + i;
                colorMaterialList.Add(Resources.Load<Material>(path));
            }
        }
    }

    private void Update()
    {
        ChangeCurrentEdges();
    }

    public void ChangeCurrentEdges()
    {
        if (player.variables.order > colorMaterialList.Count - 1) player.variables.order = 1;//Khi thứ tự màu tới cuối danh sách thì quay lại màu ban đầu

        if (player.variables.scoreInGame % 5 == 0 && player.variables.scoreInGame != 0)
        {
            player.variables.lastScore = player.variables.scoreInGame;//Ghi lại số điểm gần nhất

            player.variables.edgeColoring = true;
        }

        if(player.variables.edgeColoring)
        {
            time += Time.deltaTime;

            if (time < 0.5f && i < transform.childCount)//Thay đổi màu theo thứ tự của các con
            {
                Color meshColor = transform.GetChild(i).GetComponent<MeshRenderer>().material.color;
                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = colorMaterialList[player.variables.order].color;
                i++;

                if (i == transform.childCount) i = 0;//Khi i chạy hết thì reset lạii biến
            }

            if (temp == 0)
            {
                player.variables.order++;
                temp++;
            }
        }

        if(player.variables.scoreInGame - player.variables.lastScore == 1)//Khi điểm lớn hơn điểm gần nhất => cập nhật lại trạng thái ban đầu
        {
            player.variables.edgeColoring = false;
            time = 0;
            temp = 0;
        }
    }
}
