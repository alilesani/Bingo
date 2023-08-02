using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadNumber : MonoBehaviour
{
    [SerializeField] private Text _text;
    public void SetText(string text) {
        _text.text = text;
    }
}
