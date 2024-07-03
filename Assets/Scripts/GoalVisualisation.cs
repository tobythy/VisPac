using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalVisualisation : MonoBehaviour
{
    [SerializeField] public List<GameObject> goalProgress;
    public float goalAmount;
    public void UpdateGoalVisualisation()
    {
        for (int i = 0; i < goalProgress.Count; i++)
        {
            if (PiggyBankMoneyPool.instance.savingPlan.total >= goalAmount * (i + 1) / goalProgress.Count)
            {
                goalProgress[i].SetActive(true);
            }
            else
            {
                goalProgress[i].SetActive(false);
            }
        }
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
