using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSetup : MonoBehaviour
{
    public BallPool[] ballPool;    //array of object pool that going to be in scene

    void Start()
    {
        PoolInitializer();
    }

    /// <summary>
    /// function to start setup pool object
    /// </summary>
    private void PoolInitializer()
    {
        //loop all in need pool
        for(int i = 0 ; i < ballPool.Length - 1;i++)
        {
            //setup pool objects
            QuocAnhPoolManager.Setup(ballPool[i].ball,ballPool[i].amount);
        }
    }


}


[Serializable]
public class BallPool
{
    public BallBehaviour ball;
    public int amount;
}