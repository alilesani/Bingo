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
    private int _number;
    private bool _hasRead;

    public Label Label
    {
        get
        {
            return _label;
        }
    }
    public int Number
    {
        get { return _number; }
        set
        {
            _number = value;
            _text.text = value.ToString();
        }
    }
    public bool Clickable
    {
        set
        {
            _clickable = value;
        }
    }
    public bool HasRead { set { _hasRead = value; } }
    public void onClick()
    {
        if (_clickable)
        {

            Clicked.SetActive(!Clicked.activeSelf);
            if (_hasRead)
            {
                _clickable = false;
            }
        }
    }

}