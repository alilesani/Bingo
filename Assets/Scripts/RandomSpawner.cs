using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomSpawner : MonoBehaviour
{
   [SerializeField] private Text _turn;
   public void SetText(string text) {
    _turn.text = text;
   }
}
