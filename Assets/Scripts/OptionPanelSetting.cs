using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanelSetting : MonoBehaviour
{
    public UIManager Ui;

    private void Update()
    {
        Ui.setSetting();
    }
}
