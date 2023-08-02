using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomSpawner : MonoBehaviour
{
   [SerializeField] private GameController _gameController;
   [SerializeField] private GameObject _readPrefab;
   [SerializeField] private Transform _content;

   public List<Turn> Read { get; private set; } = new List<Turn>();
   public void GetReadData(Turn read) {
      Read.Add(read);
      GameObject newRead = Instantiate(_readPrefab, _content);
      newRead.GetComponent<Read>().SetText(read.Label + "" + read.Number);
   }
}
