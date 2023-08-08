using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GameController : MonoBehaviour
{
    // [SerializeField] private Board _board;
    [SerializeField] private RandomSpawner _randomSpawner;
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Bingo _bingo;
    [SerializeField] private GameObject _winObject;
    private int _violation;
    private List<Turn> _bag;

    public static bool Locked { get; private set; } = false;


    private void Start()
    {
        _bag = GenerateData.CreateBag();
        _bag.Sort();
        foreach (var item in _bag)
        {
            print(item);
        }
        _violation = 0;
        StartCoroutine(TakeTurn());
    }

    private IEnumerator TakeTurn()
    {
        if (_bag.Count > 0)
        {
            yield return new WaitForSeconds(0.1f);
            int selected = Random.Range(0, _bag.Count);
            StartCoroutine(_randomSpawner.GetReadData(_bag[selected]));
            _boardManager.Check(_bag[selected].Label, _bag[selected].Number);
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
                yield return new WaitForSeconds(5);
                Locked = false;
                break;
            case 2:
                print("2 ==> 10");
                yield return new WaitForSeconds(10);
                Locked = false;
                break;
            case 3:
                print("3 ==> 10");
                yield return new WaitForSeconds(10);
                Locked = false;
                break;
            case 4:
                print("4 ==> 20");
                yield return new WaitForSeconds(20);
                Locked = false;
                break;
            case 5:
                print("You Kick Out Bitch");
                break;
            default:
                yield return null;
                Locked = true;
                break;
        }

    }

    public void onBingoClicked()
    {
        if (!Locked)
        {
            bool result = false;
            Board[] boards = _boardManager.GetCurrentBoard();
            foreach (var board in boards)
            {
                if (result) break;
                result |= _bingo.CheckStatus(board.Cells);
            }
            {
                _winObject.SetActive(true);
            }
            Locked = !result;
            if (Locked)
            {
                _violation += 1;
                StartCoroutine(LockScreen());
            }
        }
    }
}
