using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GetLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _text;
    public void OnPointerClick(PointerEventData eventData)
    {
        print(_text.text);
    }
}
