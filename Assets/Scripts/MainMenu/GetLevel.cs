using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GetLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _text;
    public void OnPointerClick(PointerEventData eventData)
    {
        string text = _text.text;
        
        DataManager.instance.BoardsCount = int.Parse(_text.text);
        SceneManager.LoadScene(1);
    }
}
