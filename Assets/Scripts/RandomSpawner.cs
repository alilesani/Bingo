using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.UIElements;
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _readPrefab;
    [SerializeField] private Transform _content;


    public List<Turn> Read { get; private set; } = new List<Turn>();

    private List<GameObject> _readObjects = new List<GameObject>();

    public IEnumerator GetReadData(Turn read)
    {
        // for (int i = 0; i < _readObjects.Count; i++)
        // {
        //     _readObjects[i].transform.DOLocalMoveX(100 * (i + 1), 1f);
        // }

        
            GameObject newRead = Instantiate(_readPrefab, _content.position, Quaternion.identity, _content);
            newRead.transform.SetAsFirstSibling();
            newRead.GetComponent<Read>().SetText(read.Label + "" + read.Number);
            newRead.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 0.5f);
            _readObjects.Insert(0, newRead);
        
        print("RUNNNN");


        yield return null;
    }


}
