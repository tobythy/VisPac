using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyPool : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject moneyPoolPlatform;
    public static MoneyPool instance;
    
    //put under WhenSelect() - that's when the user selects the moneyPool, instantiate a new money sphere - whose size updates with its distance to moneyPool.
    // need to set up a maximum dragging distance 
    public void SpawnNewMoneyPool()
    {
        Money temp = Instantiate(moneyPrefab, moneyPoolPlatform.transform.position + new Vector3(0,0.1f,0), Quaternion.identity, null).GetComponent<Money>();
        temp.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        temp.transform.LeanScale(new Vector3(1f, 1f, 1f), 2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
