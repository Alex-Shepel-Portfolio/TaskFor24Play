using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankGenerator : Singleton<CubeHolder>
{
   
    [SerializeField] private GameObject[] chanks;
    private static List<GameObject> chankOnScene = new List<GameObject>();
    [SerializeField] private int maxChanks = 8;
    [SerializeField] private Transform playerPos;

    private void Start()
    {
        ResetLevel();
    }

    public void StartLevel()
    {
        SwipeManager.Instance.enabled = true;
        ResetLevel();
    }

    private void Update()
    {
        if (chankOnScene.Count > 0)
        {
            if (chankOnScene[0].transform.position.z < playerPos.position.z - 40)
            {
                RemoveChank();
                CreateNextChank();
            }
        }
    }

    private void CreateNextChank()
    {
        Vector3 pos = Vector3.zero;
        if(chankOnScene.Count > 0)
        {
            pos = chankOnScene[chankOnScene.Count - 1].transform.position + new Vector3(0, 0, 30);
        }
        int count = Random.Range(0, chanks.Length);
        GameObject createdChank = PoolManager.Instance.Spawn(chanks[count], pos, Quaternion.identity);
        ActiveElementInChank(createdChank);
        chankOnScene.Add(createdChank);
    }
    private void ActiveElementInChank(GameObject chank)
    {
        foreach (Transform item in chank.transform)
        {
            item.gameObject.SetActive(true);
        }
    }
    private void RemoveChank()
    {
        PoolManager.Instance.Despawn(chankOnScene[0]);
        chankOnScene.RemoveAt(0);
    }


    public void ResetLevel()
    {
        while(chankOnScene.Count > 0)
        {
            RemoveChank();
        }
        for (int i = 0; i < maxChanks; i++)
        {
            CreateNextChank();
        }
        SwipeManager.Instance.enabled = false;
    }

}
