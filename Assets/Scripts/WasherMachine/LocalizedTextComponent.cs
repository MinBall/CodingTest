using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedTextComponent : LocalizedComponent
{
     protected TextMeshProUGUI textComponent;
      
  
    protected override void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        onChangeAction = UpdateContent;
        LocalizationManager.Instance.AddFunctionToChangeEvent(onChangeAction);
        UpdateContent();
    }
    private void Update()
    {
        localizedCode = "MainText" + MainTextNumber.ToString("D3");
      
        //Debug.Log(localizedCode);
        UpdateContent();
    }

    protected override void UpdateContent()
    {
        textComponent.text = LocalizationManager.Instance.GetStringFromCode(localizedCode, textComponent.text);       
    }

}
