using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    int fireBall = 0;
    int bouncyBall = 0;
    int speedBall = 0;
    public int limit;
    public BallSpawner fireSpawner;
    public BallSpawner bouncySpawner;
    public BallSpawner speedSpawner;


    public void DecrementBall(GameObject obj)
    {
        switch (obj.GetComponent<BallProjectileScript>().ballType){

            case BallType.Fire:
                fireBall -= 1;
                if (fireBall < limit)
                {
                    fireSpawner.GetComponent<BallSpawner>().Populate();
                }
                break;
            case BallType.Bouncy:
                bouncyBall -= 1;
                if (bouncyBall < limit)
                {
                    bouncySpawner.GetComponent<BallSpawner>().Populate();
                }
                break;
            case BallType.Speed:
                speedBall -= 1;
                if (speedBall < limit)
                {
                    speedSpawner.GetComponent<BallSpawner>().Populate();
                }
                break;
        }
    }

    public void IncrementBall(GameObject obj)
    {
        switch (obj.GetComponent<BallProjectileScript>().ballType)
        {

            case BallType.Fire:
                fireBall += 1;
                break;
            case BallType.Bouncy:
                bouncyBall += 1;
                break;
            case BallType.Speed:
                speedBall += 1;
                break;
        }
    }
}
