
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankMoneyPool : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject moneyPoolPlatform;
    public static PiggyBankMoneyPool instance;
    public Money currSaving;
    public SavingPlan savingPlan;
    public GoalVisualisation goalVisualisation;
    public Transform piggyAnchor;
    
    //put under WhenSelect() - that's when the user selects the moneyPool, instantiate a new money sphere - whose size updates with its distance to moneyPool.
    // need to set up a maximum dragging distance 
    public void SpawnNewMoneyPool()
    {
        if (currSaving == null)
        {
            Money temp = Instantiate(moneyPrefab, moneyPoolPlatform.transform.position + new Vector3(0, 0.05f, 0),
                Quaternion.identity, null).GetComponent<Money>();
            temp.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            temp.saved = true;
            temp.initialised = true;
            currSaving = temp;
            transform.LeanScale(currSaving.UpdateSphereSize(savingPlan.total), 2f);
            currSaving.transform.LeanScale(currSaving.UpdateSphereSize(savingPlan.total), 2f);
            currSaving.transform.LeanMove(piggyAnchor.position, 2f);
        }
        else
        {
            if (savingPlan.total <= 0)
            {
                Destroy(currSaving.gameObject);
            }
            else
            {
                transform.LeanScale(currSaving.UpdateSphereSize(savingPlan.total), 2f);
                currSaving.transform.LeanScale(currSaving.UpdateSphereSize(savingPlan.total), 2f);
                currSaving.transform.LeanMove(piggyAnchor.position, 2f);
            }
        }
    }

    public void SaveMoney(float money)
    {
        savingPlan.AddPrincipal(money);
        SpawnNewMoneyPool();
        goalVisualisation.UpdateGoalVisualisation();
    }
    
    public void WithdrawMoney(float money)
    {
        savingPlan.WithdrawPrincipal(money);
        SpawnNewMoneyPool();
        goalVisualisation.UpdateGoalVisualisation();
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
