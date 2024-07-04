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
                if (!goalProgress[i].activeSelf)
                {
                    goalProgress[i].SetActive(true);
                    MovingIn(goalProgress[i]);
                }
                    
            }
            else
            {
                if (goalProgress[i].activeSelf)
                {
                    MovingOut(goalProgress[i]);
                    goalProgress[i].SetActive(false);
                }
            }
        }
    }
    
    void MovingIn(GameObject obj)
    {
        StartCoroutine(StartMovingIn(obj));
    }
	
    IEnumerator StartMovingIn(GameObject obj)
    {
        obj.transform.LeanMove(obj.transform.position -
                               new Vector3(0, 5, 0), 2f);
        yield return new WaitForSeconds(2f);
        obj.transform.LeanMove(obj.transform.position +
                               new Vector3(0, 0.25f, 0), 0.25f);
        yield return new WaitForSeconds(0.25f);
        obj.transform.LeanMove(obj.transform.position -
                               new Vector3(0, 0.25f, 0), 0.25f);
        yield return new WaitForSeconds(0.25f);
    }
    
    void MovingOut(GameObject obj)
    {
        StartCoroutine(StartMovingOut(obj));
    }
	
    IEnumerator StartMovingOut(GameObject obj)
    {
        obj.transform.LeanMove(obj.transform.position +
                               new Vector3(0, 5, 0), 2f);
        yield return new WaitForSeconds(2f);
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
