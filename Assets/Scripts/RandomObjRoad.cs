using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjRoad : MonoBehaviour
{
    [Header("Массив объектов")]
    [SerializeField] GameObject[] Obj;

    private List<GameObject> ReadyRoad = new List<GameObject>();

    [Header("Номер объекта слева")]
    [SerializeField] Vector3 pos;

    [Header("Номер объекта слева")]
    [SerializeField] int objNumderL = -1;
    [Header("Номер объекта в центре")]
    [SerializeField] int objNumderC = -1;
    [Header("Номер объекта справа")]
    [SerializeField] int objNumderR = -1;

    [Header("Рандомить до объекта")]
    [SerializeField] int numderRandom = 2;

    [Header("Статус рандома (true - активна)")]
    [SerializeField] bool stateRandom = true;

    public bool check = false;

    [SerializeField] Score score;

    void Start()
    {
        pos = transform.position;


    }
    GameObject rnd1;
    GameObject rnd2;
    GameObject rnd3;


    void FixedUpdate()
    {



        if (stateRandom)
        {
            RandomObj();
            RangeRandom();
        }

        MoveRandomObj();
        RemoveRandomObj();
    }
    float valueScore;
    float range = 300f;
    void RangeRandom()
    {
        valueScore = (int)score._score / 2;

        if (valueScore >= range && numderRandom < 7)
        {
            numderRandom++;
            range += 300f;
        }

    }


    [SerializeField] GameObject coinPrefab;

    private void RandomObj()
    {
        if (objNumderC == objNumderL && objNumderC == objNumderR)
        {
            objNumderL = Random.Range(0, numderRandom);
            objNumderC = Random.Range(0, numderRandom);
            objNumderR = Random.Range(0, numderRandom);
        }
        else
        {
            rnd1 = Instantiate(Obj[objNumderL], pos - new Vector3(1f, 0f, 0f), Quaternion.identity);
            rnd2 = Instantiate(Obj[objNumderC], pos, Quaternion.identity);
            rnd3 = Instantiate(Obj[objNumderR], pos + new Vector3(1f, 0f, 0f), Quaternion.identity);
            InstantiateCoin();
            rnd1.SetActive(true);
            rnd2.SetActive(true);
            rnd3.SetActive(true);
            ReadyRoad.Add(rnd1);
            ReadyRoad.Add(rnd2);
            ReadyRoad.Add(rnd3);
            stateRandom = false;
        }
    }

    Vector3 RandomPosCoin = new Vector3(0, 0, 0);

    private void InstantiateCoin()
    {
        RandomPosCoin = pos + new Vector3(Random.Range((int)rnd1.transform.position.x, (int)rnd3.transform.position.x), 0, 0);
        if (CheckParentCoin(RandomPosCoin))
        {
            GameObject coin = Instantiate(coinPrefab, RandomPosCoin, Quaternion.identity);
            coin.transform.SetParent(rnd2.transform, true);
        }
    }

    bool CheckParentCoin(Vector3 PosCoin)
    {
        if (PosCoin == rnd1.transform.position && objNumderL != 0)
            return true;
        else
        if (PosCoin == rnd2.transform.position && objNumderC != 0)
            return true;
        else
        if (PosCoin == rnd3.transform.position && objNumderR != 0)
            return true;
        else
            return false;

    }
    private void RemoveRandomObj()
    {
        if (check && !stateRandom)
        {
            Destroy(rnd1);
            Destroy(rnd2);
            Destroy(rnd3);
            ReadyRoad.RemoveRange(0, ReadyRoad.Count);
            objNumderL = -1;
            objNumderC = -1;
            objNumderR = -1;
            stateRandom = true;
            check = false;
        }
    }

    private void MoveRandomObj()
    {
        if (ReadyRoad.Count > 0)
        {
            foreach (GameObject readyRoad in ReadyRoad)
            {
                ReadyRoad[0].transform.localPosition = transform.position - new Vector3(1f, 0f, 0f);
                ReadyRoad[1].transform.localPosition = transform.position;
                ReadyRoad[2].transform.localPosition = transform.position + new Vector3(1f, 0f, 0f);
            }
        }
    }

    [SerializeField] GameObject destr;


    private void OnTriggerEnter(Collider other)
    {
        if (destr)
        {
            check = true;
        }
    }

}
