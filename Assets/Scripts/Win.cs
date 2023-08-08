using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _transform;
    private void OnEnable()
    {
        _transform.DOScale(new Vector3(1, 1, 1), 1.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _transform.DOScale(new Vector3(0, 0, 1), 1.5f);
        StartCoroutine(Wait());        
        
    }

    private IEnumerator Wait() {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
