using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavingPlan : MonoBehaviour
{
    public bool fixedRate;
    public float baseRate;
    public float bonusRate;
    public float interestRate
    {
        get => TermsCheck() ? baseRate + bonusRate : bonusRate;
        set { }
    }
    public float principal; // Perhaps should be changed to type Money - to be discussed
    public float interestAmount; // interestAmount + principal = total amount

    public virtual bool TermsCheck()
    {
        //TODO: if the terms are met, return true
        return true;
        
    }

    public virtual void UpdateInterest(Money money, int period) // period in months
    {
        float total = interestAmount + principal;
        money.gameObject.transform.LeanScale(money.updateSphereSize(total * interestRate * period), 2f);
    }
    
    public void AddPrincipal(Money amount)
    {
        //TODO: merge Money to Principal
    }
    
    public void WithdrawPrincipal(float time)
    {
        if (!fixedRate)
        {
            //TODO: instantiate a money prefab
            Money temp = new Money(); // placeholder, delete after completing TODO
            temp.moneyAmount = principal * time / 5; // Maximum dragging time = 5, or is it better to measure dragging distance?
            //TODO: timed-dragging to withdraw money from principal
        }
        else
        {
            //TODO: prompt user that they cannot withdraw money from a fixed rate account
        }
    }

}
