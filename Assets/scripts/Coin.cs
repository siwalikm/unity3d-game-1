using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        Speed = 4;
        transform.Rotate(0, Speed,0, (float)Space.World);
    }
}
