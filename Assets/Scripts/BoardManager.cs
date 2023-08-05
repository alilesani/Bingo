using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _availableBoards;
    private GameObject[] _selectedBoards;
    private void Start() {
        _selectedBoards = _availableBoards[0..(DataManager.instance.BoardsCount)];
        foreach (var board in _selectedBoards)
        {
            board.SetActive(true);
        }
    }
}
