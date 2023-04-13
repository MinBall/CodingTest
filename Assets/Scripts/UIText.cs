using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : LocalizedComponent
{
    public TextMeshProUGUI UITextMP;
    public int UINumber;
    // 오브젝트 1개 public int로 외부에서 받아서 TMP에 넣기
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
