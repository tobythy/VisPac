using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : SavingPlan
{
    public override bool TermsCheck()
        {
            base.TermsCheck();
            return false;
        }
        
    public override void UpdateInterest(Money moneySphere, int period)
    {
        base.UpdateInterest(moneySphere, period);
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
