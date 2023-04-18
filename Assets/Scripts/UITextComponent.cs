using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextComponent : LocalizedComponent
{
    public TextMeshProUGUI UITextMP;
    public int UINumber;
    protected override void Start()
    {               
        UITextMP=GetComponent<TextMeshProUGUI>();
        onChangeAction = UpdateContent;
        LocalizationManager.Instance.AddFunctionToChangeEvent(onChangeAction);
        UpdateContent();
    }
    private void Update()
    {
        //localizedCode = "MainText" + MainTextNumber.ToString("D3");        
        
        //Debug.Log(localizedCode);
        UpdateContent();
    }

    protected override void UpdateContent()
    {        
        UITextMP.text = LocalizationManager.Instance.GetStringFromCode(UICode[UINumber], UITextMP.text);
    }
  
}
