using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PosterSelector : MonoBehaviour
{
    public GameObject[] posterObjects;
    public Button[] selectButtons;

    private List<int> availablePosters;
    private int selectedCount = 0;

    void Start()
    {
        availablePosters = new List<int> { 0, 1, 2 };
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < posterObjects.Length; i++)
        {
            bool isAvailable = availablePosters.Contains(i);
            posterObjects[i].SetActive(isAvailable);
            if (selectButtons[i] != null)
            {
                selectButtons[i].gameObject.SetActive(isAvailable);
            }
        }
    }

    public void OnSelectButtonClicked(int posterIndex)
    {
        if (availablePosters.Contains(posterIndex))
        {
            availablePosters.Remove(posterIndex);
            selectedCount++;

            if (selectedCount == 1)
            {
                
                UpdateUI();
            }
            else
            {
                
                Debug.Log("最終選擇完成，選擇的海報索引為：" + posterIndex);
                
            }
        }
    }
}