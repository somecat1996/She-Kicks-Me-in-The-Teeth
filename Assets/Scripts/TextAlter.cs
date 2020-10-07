using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 牙齿数目不足提醒，文字变红
public class TextAlter : MonoBehaviour
{
    public Text text;
    public IEnumerator Alter()
    {
        text.color = Color.red;
        yield return new WaitForSeconds(1);
        text.color = Color.white;
        yield return null;
    }
}
