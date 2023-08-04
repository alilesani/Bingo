using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _readPrefab;
    [SerializeField] private Transform _content;

    public List<Turn> Read { get; private set; } = new List<Turn>();

    private List<GameObject> _readObjects = new List<GameObject>();

    public IEnumerator GetReadData(Turn read)
    {
        foreach (var turn in _readObjects)
        {
            turn.transform.DOLocalMoveX(1000, 2f).SetEase(Ease.OutQuad);
            print(turn.name);
        }
        //  yield return new WaitForSeconds(0.1f);
        Read.Add(read);
        GameObject newRead = Instantiate(_readPrefab, _content);
        _readObjects.Add(newRead);
        newRead.GetComponent<Read>().SetText(read.Label + "" + read.Number);
        newRead.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 2f).SetEase(Ease.OutBack);
        //   newRead.transform.DOLocalMoveX(125, 1);
        yield return null;
    }
}
