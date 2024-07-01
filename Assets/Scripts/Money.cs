using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public GameObject moneySphere;
    public float moneyAmount;

    public Vector3 updateSphereSize(float newAmount)
    {
        moneyAmount = newAmount;
        return new Vector3(moneyAmount, moneyAmount, moneyAmount); // need to scale down
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
