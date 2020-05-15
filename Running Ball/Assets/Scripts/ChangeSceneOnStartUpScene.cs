using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnStartUpScene : MonoBehaviour {
    
    void Start()
    {
        StartCoroutine(ChangeSceneDeltaTime());
    }

    IEnumerator ChangeSceneDeltaTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("RunningBall");
    }
}
