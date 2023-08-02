using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Cell : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Label _label;
    [SerializeField] private Text _text;

    [SerializeField] private GameObject Clicked;

    private int _number;
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
    public bool Clickable { get; set; } = true;
    public bool HasRead { get; set; }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (Clickable && !GameController.Locked)
        {

            Clicked.SetActive(!Clicked.activeSelf);
            if (HasRead)
            {
                Clicked.SetActive(true);
                Clickable = false;
            }
        }
    }
}