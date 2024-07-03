using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float moneyAmount;
    public bool initialising = false;
    public bool initialised = false;
    public bool saved = false;
    public GameObject tooltip;

    public Vector3 UpdateSphereSize(float newAmount)
    {
        moneyAmount = newAmount;
        return new Vector3(1, 1, 1) + new Vector3(moneyAmount, moneyAmount, moneyAmount) * .001f; // need to scale down
    }
    
    
    public void SaveToPiggyBank()
    {
        if (PiggyBankMoneyPool.instance.gameObject.GetComponent<Collider>().bounds
            .Contains(transform.position))
        {
            if (!saved)
            {
                PiggyBankMoneyPool.instance.SaveMoney(moneyAmount);
                Destroy(gameObject);
            }
        }
    }
    
    public void EndWithdrawFromPiggyBank()
    {
        initialising = false;
        if (saved)
        {
            saved = false;
            PiggyBankMoneyPool.instance.WithdrawMoney(moneyAmount);
        }
    }
    
    public void StartWithdrawFromPiggyBank()
    {
        if (PiggyBankMoneyPool.instance.gameObject.GetComponent<Collider>().bounds
                .Contains(transform.position))
        {
            if (saved)
            {
                PiggyBankMoneyPool.instance.currSaving = Instantiate(PiggyBankMoneyPool.instance.moneyPrefab, transform.position, Quaternion.identity).
                    GetComponent<Money>();
                PiggyBankMoneyPool.instance.currSaving.saved = true;
                PiggyBankMoneyPool.instance.currSaving.initialised = true;
                PiggyBankMoneyPool.instance.currSaving.moneyAmount = moneyAmount;
                transform.localScale = new Vector3(1, 1, 1);
                moneyAmount = 0;
                initialising = true;
            }
        }
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
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialised && initialising && !saved) // grab from moneypool
        {
            //tooltip.gameObject.SetActive(true);
            moneyAmount = 1000 * Vector3.Distance(transform.position,
                MoneyPool.instance.moneyPoolPlatform.transform.position);
            moneyAmount = (float)(Math.Round(moneyAmount / 100, 0) * 100);
            transform.LeanScale(UpdateSphereSize(moneyAmount), Time.deltaTime);
        }
        else if (saved && initialising && initialised) // grab from piggybank
        {
            if (moneyAmount < PiggyBankMoneyPool.instance.savingPlan.total)
            {
                moneyAmount = 1000 * Vector3.Distance(transform.position,
                    PiggyBankMoneyPool.instance.moneyPoolPlatform.transform.position);
                moneyAmount = (float)(Math.Round(moneyAmount / 100, 0) * 100);
                PiggyBankMoneyPool.instance.currSaving.transform.LeanScale(UpdateSphereSize(moneyAmount), Time.deltaTime);
            }
            transform.LeanScale(UpdateSphereSize(moneyAmount), Time.deltaTime);
        }
        else if (saved && !initialising && initialised)
        {
            // left empty so that when new coins are spawned from the piggybank, they won't 
            // fluctuate.
        }
        else if (!saved && !initialising && !initialised)
        {
            // left empty so that when new coins are spawned from the moneypool, they won't 
            // fluctuate.
        }
        else
        {
            transform.LeanScale(UpdateSphereSize(moneyAmount), Time.deltaTime);
        }
        


    }
}
