using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class LocalizedComponent : MonoBehaviour
{
    public static int MainTextNumber = 1;
    protected static string localizedCode = "MainText" + MainTextNumber.ToString("D3");
    protected static string[] UICode = {"UI001", "UI002", "UI003", "UI004", "UI005", "UI006", };
    [Space]
    //[DrawIf("specificColumnName", true, ComparisonType.Equals, DisablingType.DontDraw)]
    public string localizedColumnName = "CONTENT";

    protected UnityAction onChangeAction;
    // Start is called before the first frame update
    protected abstract void Start();


    protected abstract void UpdateContent();

    private void OnDestroy()
    {
        if(LocalizationManager.Instance)
        {
            LocalizationManager.Instance.RemoveFunctionFromChangeEvent(onChangeAction);
        }
        
    }

}



