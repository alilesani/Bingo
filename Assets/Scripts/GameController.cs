using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private RandomSpawner _randomSpawner;
    private List<Turn> _bag;
    public void Check(Label label, int number)
    {
        foreach (var item in _board.Cells.Where(item => item.GetLabel == label && item.GetText == number))
        {
            print("Unlock");
            item.Clickable = true;
        }
    }

    private void Start()
    {
        _board.SetBoardData();
        _bag = GenerateData.CreateBag();
        StartCoroutine(TakeTurn());
    }


    private IEnumerator TakeTurn()
    {
        if (_bag.Count > 0)
        {
            yield return new WaitForSeconds(1);
            int selected = Random.Range(0, _bag.Count);
            Check(_bag[selected].Label, _bag[selected].Number);
            _randomSpawner.SetText(_bag[selected].ToString());
            _bag.RemoveAt(selected);
            StartCoroutine(TakeTurn());
        }
    }
}
