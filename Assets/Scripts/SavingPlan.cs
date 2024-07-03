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
    public float principal; 
    public float interestAmount; // interestAmount + principal = total amount
    public float total { get => principal + interestAmount;}
    public virtual bool TermsCheck()
    {
        //TODO: if the terms are met, return true
        return true;
        
    }

    public virtual void UpdateInterest(Money money, int period) // period in months
    {
        float total = interestAmount + principal;
        money.gameObject.transform.LeanScale(money.UpdateSphereSize(total * interestRate * period), 2f);
    }
    
    public void AddPrincipal(float amount)
    {
        principal += amount;
    }
    
    public void WithdrawPrincipal(float amount)
    {
        principal -= amount;
        if (principal < 0)
        {
            interestAmount += principal;
            principal = 0;
        }
    }
    
    public void CalculateInterest(float time)
    {
        //TODO: calculate interest and apply interest to interestAmount
    }

}
