using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float moneyAmount;
    public bool initialising = false;
    public bool initialised = false;
    public GameObject tooltip;

    public Vector3 updateSphereSize(float newAmount)
    {
        moneyAmount = newAmount;
        return new Vector3(1, 1, 1) + new Vector3(moneyAmount, moneyAmount, moneyAmount) * .001f; // need to scale down
    }
    
    
    public void StartInitialisation()
    {
        if (!initialised)
        {
            initialising = true;
            MoneyPool.instance.SpawnNewMoneyPool();
        }
    }
    //put under WhenUnselect() - that's when the user releases the new money sphere
    public void EndInitialisation()
    {
        if (!initialised)
        {
            initialised = true;
            initialising = false;
            tooltip.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialised && initialising)
        {
            tooltip.gameObject.SetActive(true);
            moneyAmount = 1000 * Vector3.Distance(transform.position,
                MoneyPool.instance.moneyPoolPlatform.transform.position);
            moneyAmount = (float)(Math.Round(moneyAmount / 100, 0) * 100);
            transform.LeanScale(updateSphereSize(moneyAmount), Time.deltaTime);
        }
        else if (initialised)
        {
            transform.LeanScale(updateSphereSize(moneyAmount), Time.deltaTime);
        }

}
}
