using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private enum Label {
        B,
        I,
        N,
        G,
        O,
    }

    [SerializeField] private Label _label;
    [SerializeField] private Text _text;

    public void SetText(string text) {
        _text.text = text;
    }

    public string GetText() {
        return _text.text;
    }

}
