using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private RandomSpawner _randomSpawner;
    [SerializeField] private Bingo _bingo;
    private int _violation;
    private List<Turn> _bag;

    public static bool Locked { get; private set; } = false;
    public void Check(Label label, int number)
    {
        foreach (var item in _board.Cells.Where(item => item.Label == label && item.Number == number))
        {
            item.HasRead = true;
        }
    }

    private void Start()
    {
        _board.SetBoardData();
        _bag = GenerateData.CreateBag();
        _violation = 0;
        StartCoroutine(TakeTurn());
    }

    private IEnumerator TakeTurn()
    {
        if (_bag.Count > 0)
        {
            yield return new WaitForSeconds(3);
            int selected = Random.Range(0, _bag.Count);
            _randomSpawner.GetReadData(_bag[selected]);
            Check(_bag[selected].Label, _bag[selected].Number);
            _bag.RemoveAt(selected);
            StartCoroutine(TakeTurn());
        }
    }

    private IEnumerator LockScreen()
    {
        switch (_violation)
        {
            case 1:
                print("1 ==> 5");
                Locked = false;
                yield return new WaitForSeconds(5);
                break;
            case 2:
                print("2 ==> 10");
                Locked = false;
                yield return new WaitForSeconds(10);
                break;
            case 3:
                print("3 ==> 10");
                Locked = false;
                yield return new WaitForSeconds(10);
                break;
            case 4:
                print("4 ==> 20");
                Locked = false;
                yield return new WaitForSeconds(20);
                break;
            case 5:
                print("You Kick Out Bitch");
                break;
            default:
                Locked = true;
                yield return null;
                break;
        }

    }

    public void onBingoClicked()
    {
        if (!Locked)
        {
            bool result = _bingo.CheckStatus(_board.Cells);
            if (result) {
                print("Win");
            }
            Locked = !result;
        }
        if (Locked)
        {
            _violation += 1;
            StartCoroutine(LockScreen());
        }
    }
}
