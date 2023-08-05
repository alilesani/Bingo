using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Test : MonoBehaviour
{
    [SerializeField] private List<GameObject> _list;

    private void Start() {

        StartCoroutine(Add());
    }

    private IEnumerator Add() {
        yield return new WaitForSeconds(1);
        // GameObject newRead = Instantiate(_readPrefab, _content);
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].transform.DOLocalMoveX((i * 200) + 28, 1f).SetEase(Ease.OutQuad);
        }
        // newRead.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 5f).SetEase(Ease.OutQuad);
        // _readObjects.Add(newRead);
    }
}
