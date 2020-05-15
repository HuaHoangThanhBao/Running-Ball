using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variables {

    #region EdgeControl
    [System.NonSerialized]
    public float startY = 0;
    [System.NonSerialized]
    public float startZ = 2;
    #endregion


    #region Player
    [System.NonSerialized]
    public float lerpSpeed = 10f;
    [System.NonSerialized]
    public float rangeForward = 0.6f;
    [System.NonSerialized]
    public float rangeDown = 0.4f;
    [System.NonSerialized]
    public float jumpForce = 10;
    [System.NonSerialized]
    public float baseGravity = 20;
    [System.NonSerialized]
    public float gravityScale = 100;

    [System.NonSerialized]
    public bool gameBegin;
    [System.NonSerialized]
    public bool endGame;
    [System.NonSerialized]
    public bool hitTrigger;

    [System.NonSerialized]
    public int numberOfHitGround;
    [System.NonSerialized]
    public int numberHit = 0; //Biến tạm

    public LayerMask layerMask; //Chỉ có Edge + Trigger
    #endregion


    #region EdgeCloneControl
    [System.NonSerialized]
    public float downRange = 2;
    [System.NonSerialized]
    public float backRange = 1;
    [System.NonSerialized]
    public float speed = 2;

    [System.NonSerialized]
    public bool createWhenStart;
    #endregion


    #region HitCollisionAction
    [System.NonSerialized]
    public bool hitSpike;
    #endregion


    #region Edge Coloring
    [System.NonSerialized]
    public bool edgeColoring;
    [System.NonSerialized]
    public int order = 0;
    [System.NonSerialized]
    public int lastScore;
    #endregion


    #region Left Point Control
    [System.NonSerialized]
    public float yAxis_L = 1;
    [System.NonSerialized]
    public float zAxis_L = 4;
    #endregion


    #region Right Point Control
    [System.NonSerialized]
    public float yAxis_R = 1;
    [System.NonSerialized]
    public float zAxis_R = 4;
    #endregion


    #region Score Handle
    [System.NonSerialized]
    public int scoreInGame = 0;
    #endregion
}
