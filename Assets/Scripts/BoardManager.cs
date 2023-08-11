using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _availableBoardsObjects;
    [SerializeField] private Board[] _availableBoards;
    private int[] _selected = new int[] { 0, 0, 0 };
    private void Start()
    {
        for (int i = 0; i < DataManager.instance.BoardsCount; i++)
        {
            _availableBoardsObjects[i].SetActive(true);
            _availableBoards[i].SetBoardData();
        }

        if (DataManager.instance.BoardsCount > 1)
        {
            _selected[0] = DataManager.instance.BoardsCount - 1;
            _selected[1] = 0;
            _selected[2] = 1;
        }
    }

    private int next(int i)
    {
        if (i + 1 == DataManager.instance.BoardsCount) return 0;
        return i + 1;
    }

    private int previous(int i)
    {
        if (i == 0) return DataManager.instance.BoardsCount - 1;
        return i - 1;
    }

    private void MoveNext()
    {
        _availableBoardsObjects[_selected[2]].SetActive(false);
        _availableBoardsObjects[_selected[2]].transform.position = new Vector3(20, _availableBoardsObjects[_selected[2]].transform.position.y,
        _availableBoardsObjects[_selected[2]].transform.position.z);
        _availableBoardsObjects[_selected[2]].SetActive(true);
        _availableBoardsObjects[_selected[2]].transform.DOLocalMoveX(0, 0.4f);
        _availableBoardsObjects[_selected[1]].transform.DOLocalMoveX(-550, 0.5f);
        _selected[0] = next(_selected[0]);
        _selected[1] = next(_selected[1]);
        _selected[2] = next(_selected[2]);
    }
    private void MovePrevious()
    {
        _availableBoardsObjects[_selected[0]].SetActive(false);
        _availableBoardsObjects[_selected[0]].transform.position = new Vector3(-20, _availableBoardsObjects[_selected[0]].transform.position.y,
        _availableBoardsObjects[_selected[0]].transform.position.z);
        _availableBoardsObjects[_selected[0]].SetActive(true);
        _availableBoardsObjects[_selected[0]].transform.DOLocalMoveX(0, 0.4f);
        _availableBoardsObjects[_selected[1]].transform.DOLocalMoveX(
               550, 0.5f);
        _selected[0] = previous(_selected[0]);
        _selected[1] = previous(_selected[1]);
        _selected[2] = previous(_selected[2]);
    }
    public void Next()
    {
        MoveNext();
    }
    public void Previous()
    {
        MovePrevious();
    }

    public void Check(Label label, int number)
    {
        foreach (var list in _availableBoards)
        {
            foreach (var item in list.Cells.Where(item => item.Label == label && item.Number == number))
            {
                item.HasRead = true;
            }
        }
    }

    public Board GetCurrentBoard()
    {
        return _availableBoards[_selected[1]];
    }

}
