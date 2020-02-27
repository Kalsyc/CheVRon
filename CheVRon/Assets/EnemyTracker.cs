using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyTracker : MonoBehaviour
{
    public enum EnemyType
    {
        Spider,
        Golem
    };

    private int numOfSpider = 0;
    private int numOfGolem = 0;

    public int GetNumSpider()
    {
        return this.numOfSpider;
    }

    public int GetNumGolem()
    {
        return this.numOfGolem;
    }


    public void IncrementSpider()
    {
        numOfSpider++;
    }

    public void DecrementSpider()
    {
        numOfSpider--;

    }

    public void IncrementGolem()
    {
        numOfGolem++;
    }

    public void DecrementGolem()
    {
        numOfGolem--;

    }

}