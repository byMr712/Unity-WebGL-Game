using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;

    //int _HeartCount = 0;
    //int _HeartCountTest = 0;

    private void Start()
    {
        // Should I use lists? Maybe :)
        heartContainers = new GameObject[(int)PlayerStats.Instance.MaxTotalHealth];
        heartFills = new Image[(int)PlayerStats.Instance.MaxTotalHealth];

        PlayerStats.Instance.onHealthChangedCallback += UpdateHeartsHUD;
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < PlayerStats.Instance.MaxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }

        //for (Convert.ToInt32(heartContainers.Length); _HeartCount < heartContainers.Length; _HeartCount++)
        //{
        //    if (_HeartCount < PlayerStats.Instance.MaxHealth)
        //    {
        //        heartContainers[_HeartCount].SetActive(true);
        //    }
        //    else
        //    {
        //        heartContainers[_HeartCount].SetActive(false);
        //    }
        //}

    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < PlayerStats.Instance.Health)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (PlayerStats.Instance.Health % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(PlayerStats.Instance.Health);
            heartFills[lastPos].fillAmount = PlayerStats.Instance.Health % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < PlayerStats.Instance.MaxTotalHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }

        //for (Convert.ToInt32(PlayerStats.Instance.MaxTotalHealth); _HeartCountTest < PlayerStats.Instance.MaxTotalHealth; _HeartCountTest++)
        //{
        //    GameObject temp = Instantiate(heartContainerPrefab);
        //    temp.transform.SetParent(heartsParent, false);
        //    heartContainers[_HeartCountTest] = temp;
        //    heartFills[_HeartCountTest] = temp.transform.Find("HeartFill").GetComponent<Image>();
        //}

    }
}
