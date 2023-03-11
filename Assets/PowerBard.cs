using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBard : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] Image jump;
    [SerializeField] Image punish;
    [SerializeField] Image charge;

    public float holdAmount;
    public bool enableJump;
    public bool enablePunish;
    public bool enableCharge;

    private void Update()
    {
        mask.fillAmount = holdAmount;
        jump.enabled = enableJump;
        punish.enabled = enablePunish;
        charge.enabled = enableCharge;
    }
}


