using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public Animator grandmaButtonAnimator;
    public Animator grandpaButtonAnimator;
    public Animator auntieButtonAnimator;
    public Animator girlButtonAnimator;
    public Animator babyButtonAnimator;

    public MenuAudioController audioController;

    public TextAlter money;

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


        switch (PlayerPrefs.GetInt("Auntie"))
        {
            case 0: PlayerPrefs.SetInt("Auntie", 1); break;
            case 1: break;
            case 2: auntieButtonAnimator.SetBool("Bought", true); break;
            default: PlayerPrefs.SetInt("Auntie", 1); break;
        }


        switch (PlayerPrefs.GetInt("Girl"))
        {
            case 0: PlayerPrefs.SetInt("Girl", 1); break;
            case 1: break;
            case 2: girlButtonAnimator.SetBool("Bought", true); break;
            default: PlayerPrefs.SetInt("Girl", 1); break;
        }


        switch (PlayerPrefs.GetInt("Baby"))
        {
            case 0: PlayerPrefs.SetInt("Baby", 1); break;
            case 1: break;
            case 2: babyButtonAnimator.SetBool("Bought", true); break;
            default: PlayerPrefs.SetInt("Baby", 1); break;
        }

        switch (PlayerPrefs.GetString("Selected"))
        {
            case "Grandma": grandmaButtonAnimator.SetBool("Check", true); break;
            case "Grandpa": grandpaButtonAnimator.SetBool("Check", true); break;
            case "Auntie": auntieButtonAnimator.SetBool("Check", true); break;
            case "Girl": girlButtonAnimator.SetBool("Check", true); break;
            case "Baby": babyButtonAnimator.SetBool("Check", true); break;
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
            case "Grandpa":
                if (Wallet.Single.RemoveGold(100))
                {
                    audioController.OnPay();
                    PlayerPrefs.SetInt("Grandpa", 2);
                    grandpaButtonAnimator.SetBool("Bought", true);
                    OnSelect(name);
                    if (PlayerPrefs.GetInt("ArchievementFlower2") == 0) PlayerPrefs.SetInt("ArchievementFlower2", 1);
                }
                else
                {
                    audioController.OnError();
                    StartCoroutine(money.Alter());
                }
                break;
            case "Auntie":
                if (Wallet.Single.RemoveGold(500))
                {
                    audioController.OnPay();
                    PlayerPrefs.SetInt("Auntie", 2); 
                    auntieButtonAnimator.SetBool("Bought", true);
                    OnSelect(name);
                    if (PlayerPrefs.GetInt("ArchievementRing") == 0) PlayerPrefs.SetInt("ArchievementRing", 1);
                }
                else
                {
                    audioController.OnError();
                    StartCoroutine(money.Alter());
                }
                break;
            case "Girl":
                if (Wallet.Single.RemoveGold(1000))
                {
                    audioController.OnPay();
                    PlayerPrefs.SetInt("Girl", 2);
                    girlButtonAnimator.SetBool("Bought", true);
                    OnSelect(name);
                    if (PlayerPrefs.GetInt("ArchievementComponent") == 0) PlayerPrefs.SetInt("ArchievementComponent", 1);
                }
                else
                {
                    audioController.OnError();
                    StartCoroutine(money.Alter());
                }
                break; 
            case "Baby":
                if (Wallet.Single.RemoveGold(5000))
                {
                    audioController.OnPay();
                    PlayerPrefs.SetInt("Baby", 2);
                    babyButtonAnimator.SetBool("Bought", true);
                    OnSelect(name);
                    if (PlayerPrefs.GetInt("ArchievementFish") == 0) PlayerPrefs.SetInt("ArchievementFish", 1);
                }
                else
                {
                    audioController.OnError();
                    StartCoroutine(money.Alter());
                }
                break; 
            default: break;
        }
    }

    private void OnSelect(string name)
    {
        Unselect();
        switch (name)
        {
            case "Grandma": PlayerPrefs.SetString("Selected", "Grandma"); grandmaButtonAnimator.SetBool("Check", true); break;
            case "Grandpa": PlayerPrefs.SetString("Selected", "Grandpa"); grandpaButtonAnimator.SetBool("Check", true); break;
            case "Auntie": PlayerPrefs.SetString("Selected", "Auntie"); auntieButtonAnimator.SetBool("Check", true); break;
            case "Girl": PlayerPrefs.SetString("Selected", "Girl"); girlButtonAnimator.SetBool("Check", true); break;
            case "Baby": PlayerPrefs.SetString("Selected", "Baby"); babyButtonAnimator.SetBool("Check", true); break;
            default: break;
        }
    }

    private void Unselect()
    {
        switch (PlayerPrefs.GetString("Selected"))
        {
            case "Grandma": grandmaButtonAnimator.SetBool("Check", false); break;
            case "Grandpa": grandpaButtonAnimator.SetBool("Check", false); break;
            case "Auntie": auntieButtonAnimator.SetBool("Check", false); break;
            case "Girl": girlButtonAnimator.SetBool("Check", false); break;
            case "Baby": babyButtonAnimator.SetBool("Check", false); break;
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
        PlayerPrefs.SetInt("Auntie", 1);
        PlayerPrefs.SetInt("Girl", 1);
        PlayerPrefs.SetInt("Baby", 1);
        PlayerPrefs.SetString("Selected", "Grandma");
    }


}
