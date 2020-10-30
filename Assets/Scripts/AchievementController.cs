using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public Animator Stone;
    public Animator Flower1;
    public Animator Flower2;
    public Animator Fish;
    public Animator Knife;
    public Animator Component;
    public Animator Ring;
    public Animator Teeth1;
    public Animator Teeth2;
    public Animator Teeth3;
    public Animator Medicine;
    // Start is called before the first frame update
    // 初始化
    void Start()
    {
        // 完全初始化
        // Reset();
        // 初始化，0--未获得，1--已获得未展示，2--已展示
        switch (PlayerPrefs.GetInt("ArchievementStone"))
        {
            case 0: Stone.SetBool("Exist", false); break;
            case 1: break;
            case 2: Stone.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementStone", 0); Stone.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFlower1"))
        {
            case 0: Flower1.SetBool("Exist", false); break;
            case 1: break;
            case 2: Flower1.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFlower1", 0); Flower1.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFlower2"))
        {
            case 0: Flower2.SetBool("Exist", false); break;
            case 1: break;
            case 2: Flower2.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFlower2", 0); Flower2.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFish"))
        {
            case 0: Fish.SetBool("Exist", false); break;
            case 1: break;
            case 2: Fish.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFish", 0); Fish.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementKnife"))
        {
            case 0: Knife.SetBool("Exist", false); break;
            case 1: break;
            case 2: Knife.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementKnife", 0); Knife.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementComponent"))
        {
            case 0: Component.SetBool("Exist", false); break;
            case 1: break;
            case 2: Component.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementComponent", 0); Component.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementRing"))
        {
            case 0: Ring.SetBool("Exist", false); break;
            case 1: break;
            case 2: Ring.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementRing", 0); Ring.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth1"))
        {
            case 0: Teeth1.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth1.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth1", 0); Teeth1.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth2"))
        {
            case 0: Teeth2.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth2.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth2", 0); Teeth2.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth3"))
        {
            case 0: Teeth3.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth3.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth3", 0); Teeth3.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementMedicine"))
        {
            case 0: Medicine.SetBool("Exist", false); break;
            case 1: break;
            case 2: Medicine.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementMedicine", 0); Medicine.SetBool("Exist", false); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 打开archieve后，放置新获得的物品
    public void OnUpdate()
    {
        if (PlayerPrefs.GetInt("ArchievementStone") == 1)
        {
            PlayerPrefs.SetInt("ArchievementStone", 2);
            Stone.SetTrigger("Appear");
            Stone.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementFlower1") == 1)
        {
            PlayerPrefs.SetInt("ArchievementFlower1", 2);
            Flower1.SetTrigger("Appear");
            Flower1.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementFlower2") == 1)
        {
            PlayerPrefs.SetInt("ArchievementFlower2", 2);
            Flower2.SetTrigger("Appear");
            Flower2.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementFish") == 1)
        {
            PlayerPrefs.SetInt("ArchievementFish", 2);
            Fish.SetTrigger("Appear");
            Fish.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementKnife") == 1)
        {
            PlayerPrefs.SetInt("ArchievementKnife", 2);
            Knife.SetTrigger("Appear");
            Knife.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementComponent") == 1)
        {
            PlayerPrefs.SetInt("ArchievementComponent", 2);
            Component.SetTrigger("Appear");
            Component.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementRing") == 1)
        {
            PlayerPrefs.SetInt("ArchievementRing", 2);
            Ring.SetTrigger("Appear");
            Ring.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementTeeth1") == 1)
        {
            PlayerPrefs.SetInt("ArchievementTeeth1", 2);
            Teeth1.SetTrigger("Appear");
            Teeth1.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementTeeth2") == 1)
        {
            PlayerPrefs.SetInt("ArchievementTeeth2", 2);
            Teeth2.SetTrigger("Appear");
            Teeth2.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementTeeth3") == 1)
        {
            PlayerPrefs.SetInt("ArchievementTeeth3", 2);
            Teeth3.SetTrigger("Appear");
            Teeth3.SetBool("Exist", true);
        }
        if (PlayerPrefs.GetInt("ArchievementMedicine") == 1)
        {
            PlayerPrefs.SetInt("ArchievementMedicine", 2);
            Medicine.SetTrigger("Appear");
            Medicine.SetBool("Exist", true);
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("ArchievementStone", 0);
        PlayerPrefs.SetInt("ArchievementFlower1", 0);
        PlayerPrefs.SetInt("ArchievementFlower2", 0);
        PlayerPrefs.SetInt("ArchievementFish", 0);
        PlayerPrefs.SetInt("ArchievementKnife", 0);
        PlayerPrefs.SetInt("ArchievementComponent", 0);
        PlayerPrefs.SetInt("ArchievementRing", 0);
        PlayerPrefs.SetInt("ArchievementTeeth1", 0);
        PlayerPrefs.SetInt("ArchievementTeeth2", 0);
        PlayerPrefs.SetInt("ArchievementTeeth3", 0);
        PlayerPrefs.SetInt("ArchievementMedicine", 0);


        switch (PlayerPrefs.GetInt("ArchievementStone"))
        {
            case 0: Stone.SetBool("Exist", false); break;
            case 1: break;
            case 2: Stone.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementStone", 0); Stone.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFlower1"))
        {
            case 0: Flower1.SetBool("Exist", false); break;
            case 1: break;
            case 2: Flower1.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFlower1", 0); Flower1.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFlower2"))
        {
            case 0: Flower2.SetBool("Exist", false); break;
            case 1: break;
            case 2: Flower2.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFlower2", 0); Flower2.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementFish"))
        {
            case 0: Fish.SetBool("Exist", false); break;
            case 1: break;
            case 2: Fish.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementFish", 0); Fish.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementKnife"))
        {
            case 0: Knife.SetBool("Exist", false); break;
            case 1: break;
            case 2: Knife.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementKnife", 0); Knife.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementComponent"))
        {
            case 0: Component.SetBool("Exist", false); break;
            case 1: break;
            case 2: Component.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementComponent", 0); Component.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementRing"))
        {
            case 0: Ring.SetBool("Exist", false); break;
            case 1: break;
            case 2: Ring.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementRing", 0); Ring.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth1"))
        {
            case 0: Teeth1.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth1.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth1", 0); Teeth1.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth2"))
        {
            case 0: Teeth2.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth2.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth2", 0); Teeth2.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementTeeth3"))
        {
            case 0: Teeth3.SetBool("Exist", false); break;
            case 1: break;
            case 2: Teeth3.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementTeeth3", 0); Teeth3.SetBool("Exist", false); break;
        }
        switch (PlayerPrefs.GetInt("ArchievementMedicine"))
        {
            case 0: Medicine.SetBool("Exist", false); break;
            case 1: break;
            case 2: Medicine.SetBool("Exist", true); break;
            default: PlayerPrefs.SetInt("ArchievementMedicine", 0); Medicine.SetBool("Exist", false); break;
        }

        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TotalDeath", 0);
    }
}
