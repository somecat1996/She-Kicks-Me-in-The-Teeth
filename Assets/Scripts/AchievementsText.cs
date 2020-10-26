using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsText : MonoBehaviour
{
    public Text text;

    private string teeth1Hint = "遥远的200米之外";
    private string teeth2Hint = "500米的惊喜";
    private string teeth3Hint = "意识模糊的1000米";
    private string stoneHint = "逐渐成熟";
    private string medicineHint = "沉积和等待";
    private string knifeHint = "利刃";
    private string fishHint = "上钩了";
    private string flower1Hint = "被扼杀";
    private string flower2Hint = "萌芽";
    private string componentHint = "重要的一部分";
    private string ringHint = "孤注一掷";

    private string teeth1Normal = "一颗脱落的烤瓷牙";
    private string teeth2Normal = "一颗完整的金牙";
    private string teeth3Normal = "一颗蛀坏的虎牙";
    private string stoneNormal = "蛮贵的紫水晶";
    private string medicineNormal = "易燃易爆的白色粉末";
    private string knifeNormal = "某种生物的牙做的刀";
    private string fishNormal = "某种生物的牙做的钩";
    private string flower1Normal = "某种植物";
    private string flower2Normal = "一朵假花";
    private string componentNormal = "某种金属零件";
    private string ringNormal = "鲨鱼牙";

    private string teeth1Special = "脱落于一颗健康的牙，虽然脱落的时候已经不健康了";
    private string teeth2Special = "";
    private string teeth3Special = "恰好踢掉了小男生的蛀牙";
    private string stoneSpecial = "";
    private string medicineSpecial = "没用几次就被禁了";
    private string knifeSpecial = "装饰品";
    private string fishSpecial = "养死的鱼被晒成了鱼干";
    private string flower1Special = "还没开花就枯了";
    private string flower2Special = "旧报纸折的玫瑰";
    private string componentSpecial = "坏掉的自行车";
    private string ringSpecial = "";
    // Start is called before the first frame update
    public void OnShow(string name)
    {
        switch (name)
        {
            case "Teeth1": ShowTeeth1(); break;
            case "Teeth2": ShowTeeth2(); break;
            case "Teeth3": ShowTeeth3(); break;
            case "Stone": ShowStone(); break;
            case "Medicine": ShowMedicine(); break;
            case "Knife": ShowKnife(); break;
            case "Fish": ShowFish(); break;
            case "Flower1": ShowFlower1(); break;
            case "Flower2": ShowFlower2(); break;
            case "Component": ShowComponent(); break;
            case "Ring": ShowRing(); break;
            default: text.text = "Error!"; break;
        }
    }

    void ShowTeeth1()
    {
        switch (PlayerPrefs.GetInt("ArchievementTeeth1"))
        {
            case 0: 
                text.text = teeth1Hint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Auntie") text.text = teeth1Special;
                else text.text = teeth1Normal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementTeeth1", 0);
                text.text = teeth1Hint;
                break;
        }
    }

    void ShowTeeth2()
    {
        switch (PlayerPrefs.GetInt("ArchievementTeeth2"))
        {
            case 0: 
                text.text = teeth2Hint; 
                break;
            case 2:
                text.text = teeth2Normal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementTeeth2", 0);
                text.text = teeth2Hint;
                break;
        }
    }

    void ShowTeeth3()
    {
        switch (PlayerPrefs.GetInt("ArchievementTeeth3"))
        {
            case 0: 
                text.text = teeth3Hint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Girl") text.text = teeth3Special;
                else text.text = teeth3Normal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementTeeth3", 0);
                text.text = teeth3Hint;
                break;
        }
    }

    void ShowStone()
    {
        switch (PlayerPrefs.GetInt("ArchievementStone"))
        {
            case 0: 
                text.text = stoneHint; 
                break;
            case 2:
                text.text = stoneNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementStone", 0);
                text.text = stoneHint;
                break;
        }
    }

    void ShowMedicine()
    {
        switch (PlayerPrefs.GetInt("ArchievementMedicine"))
        {
            case 0: 
                text.text = medicineHint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Grandma") text.text = medicineSpecial;
                else text.text = medicineNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementMedicine", 0);
                text.text = medicineHint;
                break;
        }
    }

    void ShowKnife()
    {
        switch (PlayerPrefs.GetInt("ArchievementKnife"))
        {
            case 0: 
                text.text = knifeHint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Girl") text.text = knifeSpecial;
                else text.text = knifeNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementKnife", 0);
                text.text = knifeHint;
                break;
        }
    }

    void ShowFish()
    {
        switch (PlayerPrefs.GetInt("ArchievementFish"))
        {
            case 0: 
                text.text = fishHint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Baby") text.text = fishSpecial;
                else text.text = fishNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementFish", 0);
                text.text = fishHint;
                break;
        }
    }

    void ShowFlower1()
    {
        switch (PlayerPrefs.GetInt("ArchievementFlower1"))
        {
            case 0: 
                text.text = flower1Hint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Auntie") text.text = flower1Special;
                else text.text = flower1Normal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementFlower1", 0);
                text.text = flower1Hint;
                break;
        }
    }

    void ShowFlower2()
    {
        switch (PlayerPrefs.GetInt("ArchievementFlower2"))
        {
            case 0: 
                text.text = flower2Hint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Grandpa") text.text = flower2Special;
                else text.text = flower2Normal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementFlower2", 0);
                text.text = flower2Hint;
                break;
        }
    }

    void ShowComponent()
    {
        switch (PlayerPrefs.GetInt("ArchievementComponent"))
        {
            case 0: 
                text.text = componentHint; 
                break;
            case 2:
                if (PlayerPrefs.GetString("Selected") == "Grandpa") text.text = componentSpecial;
                else text.text = componentNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementComponent", 0);
                text.text = componentHint;
                break;
        }
    }

    void ShowRing()
    {
        switch (PlayerPrefs.GetInt("ArchievementRing"))
        {
            case 0: 
                text.text = ringHint; 
                break;
            case 2:
                text.text = ringNormal;
                break;
            default:
                PlayerPrefs.SetInt("ArchievementRing", 0);
                text.text = ringHint;
                break;
        }
    }
}
