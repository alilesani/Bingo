using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private RandomSpawner _randomSpawner;
    private List<Turn> _bag;
    private List<Turn> _read;

    public List<Turn> Read { get { return _read; } }
    public void Check(Label label, int number)
    {
        foreach (var item in _board.Cells.Where(item => item.GetLabel == label && item.GetText == number))
        {
            item.HasRead();
        }
    }

    private void Start()
    {
        _board.SetBoardData();
        _bag = GenerateData.CreateBag();
        _read = new List<Turn>();
        StartCoroutine(TakeTurn());
    }


    private IEnumerator TakeTurn()
    {
        print(_bag.Count);
        if (_bag.Count > 0)
        {
            yield return new WaitForSeconds(1);
            int selected = Random.Range(0, _bag.Count);
            _randomSpawner.SetText(_bag[selected].ToString());
            _read.Add(_bag[selected]);
            Check(_bag[selected].Label, _bag[selected].Number);
            _bag.RemoveAt(selected);
            StartCoroutine(TakeTurn());
        }
    }
}
