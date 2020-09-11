using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletUIManage : MonoBehaviour
{
    [Header("金牙数量文本")]
    public Text gold;

    private void Update()
    {
        gold.text = Wallet.Single.Gold.ToString();
    }
}
