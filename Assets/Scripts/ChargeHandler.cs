using System;
using UnityEngine;

public class ChargeHandler : MonoBehaviour
{
    public float timeScale = 0.25f;
    public float charge = 0;
    public float maxCharge = 1;
    private bool charging = false;

    private void Update()
    {
        if (charging)
        {
            charge += Time.deltaTime * timeScale;
            charge = Mathf.Min(charge, maxCharge);
        }
    }

    public void StartCharge()
    {
        charge = 0;
        charging = true;
    }

    public void ResetCharge()
    {
        charge = 0;
        charging = false;
    }
}