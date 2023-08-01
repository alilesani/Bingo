using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cell : MonoBehaviour
{

    [SerializeField] private Label _label;
    [SerializeField] private Text _text;

    [SerializeField] private GameObject Clicked;

    private bool _clickable = true;
    private bool _hasRead;
    private int _number;
    public bool Clickable
    {
        set
        {
            _clickable = value;
        }
    }

    public int GetText {
        get {
            return _number;
        }
    }

    public Label GetLabel {
        get {
            return _label;
        }
    }
    public void SetText(int text)
    {
        _text.text = text.ToString();
        _number = text;
    }

    public void HasRead() {
        _hasRead = true;
    }
    public void onClick()
    {
        if (_clickable)
        {

            Clicked.SetActive(!Clicked.activeSelf);
            if (_hasRead) {
                _clickable = false;
            }
        }
    }

}