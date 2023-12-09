using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloseButton : MonoBehaviour
{
    public Button panelButton;
    public void OnClickButton()
    {
        panelButton.interactable = true;
    }
}
