using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public Animator grandmaButtonAnimator;
    public Animator grandpaButtonAnimator;
    //public Animator auntieButtonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // 完全初始化，清除所有购买记录
        ResetStore();
        // 初始化商店
        // 0 -- 未设置，1 -- 未购买，2 -- 已购买
        switch (PlayerPrefs.GetInt("Grandma"))
        {
            case 0: 
            case 1: PlayerPrefs.SetInt("Grandma", 2); grandmaButtonAnimator.SetBool("Bought", true); break;
            case 2: grandmaButtonAnimator.SetBool("Bought", true); break;
            default: PlayerPrefs.SetInt("Grandma", 2); grandmaButtonAnimator.SetBool("Bought", true); break;
        }


        switch (PlayerPrefs.GetInt("Grandpa"))
        {
            case 0: PlayerPrefs.SetInt("Grandpa", 1); break;
            case 1: break;
            case 2: grandpaButtonAnimator.SetBool("Bought", true); break;
            default: PlayerPrefs.SetInt("Grandpa", 1); break;
        }


        //switch (PlayerPrefs.GetInt("Auntie"))
        //{
        //    case 0: PlayerPrefs.SetInt("Auntie", 1); break;
        //    case 1: break;
        //    case 2: auntieButtonAnimator.SetBool("Bought", true); break;
        //    default: PlayerPrefs.SetInt("Auntie", 1); break;
        //}

        switch (PlayerPrefs.GetString("Selected"))
        {
            case "Grandma": grandmaButtonAnimator.SetBool("Check", true); break;
            case "Grandpa": grandpaButtonAnimator.SetBool("Check", true); break;
            default: grandmaButtonAnimator.SetBool("Check", true); PlayerPrefs.SetString("Selected", "Grandma"); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBuy(string name)
    {
        switch (name)
        {
            case "Grandma": break;
            case "Grandpa": PlayerPrefs.SetInt("Grandpa", 2); grandpaButtonAnimator.SetBool("Bought", true); Wallet.Single.RemoveGold(100); break;
            default: break;
        }
        OnSelect(name);
    }

    private void OnSelect(string name)
    {
        Unselect();
        switch (name)
        {
            case "Grandma": PlayerPrefs.SetString("Selected", "Grandma"); grandmaButtonAnimator.SetBool("Check", true); break;
            case "Grandpa": PlayerPrefs.SetString("Selected", "Grandpa"); grandpaButtonAnimator.SetBool("Check", true); break;
            default: break;
        }
    }

    private void Unselect()
    {
        switch (PlayerPrefs.GetString("Selected"))
        {
            case "Grandma": grandmaButtonAnimator.SetBool("Check", false); break;
            case "Grandpa": grandpaButtonAnimator.SetBool("Check", false); break;
            default: break;
        }
    }

    public void OnClick(string name)
    {
        switch (PlayerPrefs.GetInt(name))
        {
            case 1: OnBuy(name); break;
            case 2: OnSelect(name); break;
            default: break;
        }
    }

    private void ResetStore()
    {
        PlayerPrefs.SetInt("Grandma", 2);
        PlayerPrefs.SetInt("Grandpa", 1);
        PlayerPrefs.SetString("Selected", "Grandma");
    }
}
