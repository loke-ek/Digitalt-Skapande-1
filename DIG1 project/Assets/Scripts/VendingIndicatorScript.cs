using System;
using Unity.VisualScripting;
using UnityEngine;

public class VendingIndicatorScript : MonoBehaviour
{
    [SerializeField] private float indicatorPosMin;
    [SerializeField] private float indicatorPosMax;
    [SerializeField] private float indicatorSpeed;

    //bool indicatorActive = false;

    void Start()
    {
        
    }

    void Update()
    {
        //if (indicatorActive)
        {
            //float y = Mathf.PingPong(Time.time * indicatorSpeed, 1) * indicatorPosMax - indicatorPosMin;
            //transform.position = new Vector3(transform.position.x, y, 0);
        }
    }
}
