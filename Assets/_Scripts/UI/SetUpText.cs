using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpText : MonoBehaviour
{
    private Text _text;
    private Text Text { get { return (_text == null) ? _text = GetComponent<Text>() : _text; } }

    private Panel _panel;
    private Panel Panel { get { return (_panel == null)? _panel = GetComponent<Panel>() : _panel; } }

    public void SetText(string value)
    {
        Text.text = value;
    }

    public void DisplayText()
    {
        Panel.ShowPanel();
    }

    public void HideText()
    {
        Panel.HidePanel();
    }
}
