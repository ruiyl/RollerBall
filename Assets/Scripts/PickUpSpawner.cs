using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PickUpSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] pickUpList;

        public int WinScore { get; private set; }

        public void RestartGame()
        {
            WinScore = WinScore == 0 ? pickUpList.Length : Random.Range(1, pickUpList.Length);
            List<int> pickUpIndexList = GetRandomIndex(WinScore);
            for (int i = 0; i < WinScore; i++)
            {
                pickUpList[pickUpIndexList[i]].SetActive(true);
            }
        }

        private List<int> GetRandomIndex(int amount)
        {
            List<int> pickUpIndexList = new List<int>(pickUpList.Length);
            for (int i = 0; i < pickUpList.Length; i++)
            {
                pickUpIndexList.Add(i);
            }
            int removeCount = pickUpList.Length - amount;
            for (int i = 0; i < removeCount; i++)
            {
                pickUpIndexList.RemoveAt(Random.Range(0, pickUpIndexList.Count));
            }
            return pickUpIndexList;
        }
    }
}