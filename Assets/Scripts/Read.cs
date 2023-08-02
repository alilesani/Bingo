using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Read : MonoBehaviour
{
    [SerializeField] private ReadNumber _readNumber;
    public void SetText(string text) {
        _readNumber.SetText(text);
    }
}
