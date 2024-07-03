using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public Money money;
    public string tipText = "";

    public TMP_Text tip;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tip.text = tipText+ money.moneyAmount.ToString();
        Vector3 directionToCamera = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

    }
}
