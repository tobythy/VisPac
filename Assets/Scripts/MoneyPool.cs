using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPool : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject moneyPool;
    public GameObject draggedMoneyPool;
    
    //put under WhenSelect() - that's when the user selects the moneyPool, instantiate a new money sphere - whose size updates with its distance to moneyPool.
    // need to set up a maximum dragging distance 
    public void SpawnNewMoneyPool()
    {
        //TODO: instantiate a money prefab to replace the dragged money pool
        draggedMoneyPool = moneyPool;
        Money temp = Instantiate(moneyPrefab, moneyPool.transform.position, Quaternion.identity, null).GetComponent<Money>();
        temp.transform.LeanScale(new Vector3(1, 1, 1), 2f);
        moneyPool = temp.gameObject;
    }
    //put under WhenUnselect() - that's when the user releases the new money sphere
    public void ReleaseDraggedMoney()
    {
        draggedMoneyPool = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (draggedMoneyPool != null)
        {
            float amount = 100 * Vector3.Distance(draggedMoneyPool.transform.position, moneyPool.transform.position);
            amount = (float)(Math.Round(amount / 100, 0) * 100);
            draggedMoneyPool.transform.localScale = draggedMoneyPool.GetComponent<Money>().updateSphereSize(amount);
        }
    }
}
