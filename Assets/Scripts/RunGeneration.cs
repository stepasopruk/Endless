using System.Collections.Generic;
using UnityEngine;

public class RunGeneration : MonoBehaviour
{
    private List<GameObject> ReadyRoad = new List<GameObject>(); //список готовых объектов

    [Header("Массив объектов")]
    [SerializeField] GameObject[] Road;

    [Header("Статус активных объектов")]
    [SerializeField] bool[] roadNumbers;

    [Header("Статус генерации (true - генерация активна)")]
    [SerializeField] public bool StateGeneration = true;

    [Header("Текущая длина дороги")]
    [SerializeField] int currentRoadLenght = 0;

    [Header("Максимальная длина дороги")]
    [SerializeField] int maximumRoadLenght = 6;

    [Header("Текущий номер объекта")]
    [SerializeField] int currentRoadNumder = -1;

    [Header("Последний номер объекта")]
    [SerializeField] int LastRoadNumder = -1;

    [Header("Дистанция между объектами")]
    [SerializeField] float distanceDetweenRoads;

    [Header("Скорость перемещения дороги")]
    [SerializeField] public float speedRoad = 5f;

    [Header("Позиция при которой исчезает дорога(по z)")]
    [SerializeField] float maxsimumPositionZ = -15f;

    [Header("Зона ожидания объектов")]
    [SerializeField] Vector3 waitingZona = new Vector3(0f, 0f, -40f);


    private void FixedUpdate()
    {
        if (StateGeneration)
        {
            if (currentRoadLenght != maximumRoadLenght)//текущая длина дороги объектов не равна максимальной длины дороги объектов
            {
                currentRoadNumder = Random.Range(0, Road.Length);// рандомно выбираем номер объекта от 0 до длины массива объектов

                if (currentRoadNumder != LastRoadNumder)//если текущий номер объекта не равен последнему номеру объекта
                {
                    if (currentRoadNumder < Road.Length / 2)//если текущий номер объекта меньше массива объектов деленного на 2
                    {
                        if (roadNumbers[currentRoadNumder] != true)//если статус активных объектов не равен истина
                        {
                            if (LastRoadNumder != (Road.Length / 2) + currentRoadNumder)//если последний номер объекта не равен половине длины массива объектов плюс текущий номер объекта
                            {
                                RoadCreation();//метод генерации объектов
                            }
                            else if (LastRoadNumder == (Road.Length / 2) + currentRoadNumder && currentRoadLenght == Road.Length - 1)//если остался последний объект, а предыдущий такой же объект
                            {
                                RoadCreation();//метод генерации объектов
                            }
                        }
                    }
                    else if (currentRoadNumder >= Road.Length / 2)//если текущий номер объекта больше или равен половины массива объектов
                    {
                        if (roadNumbers[currentRoadNumder] != true)//если у текущего объекта, в статусе активных объектов не равно истина 
                        {
                            if (LastRoadNumder != (Road.Length / 2) + currentRoadNumder)//если последний номер объекта не равен длине половины массива объектов плюс текущий номер объекта
                            {
                                RoadCreation();//метод генерации объектов
                            }
                            else if (LastRoadNumder == (Road.Length / 2) + currentRoadNumder && currentRoadLenght == Road.Length - 1)//если остался последний объект, а предыдущий такой же объект
                            {
                                RoadCreation();//метод генерации объектов
                            }
                        }
                    }
                }
            }
            MovingRoad();// мотод перемещения объектов

            if (ReadyRoad.Count != 0)//если длина готовых объектов не равна нулю
            {
                RemovingRoad();//метод удаления объектов
            }
        }

    }

    void MovingRoad()// мотод перемещения объектов
    {
        foreach (GameObject readyRoad in ReadyRoad)// перемещаем каждый готовый объект со скоростью
        {
            readyRoad.transform.localPosition -= new Vector3(0f, 0f, speedRoad * Time.fixedDeltaTime);
        }
    }

    void RemovingRoad()//метод удаления объектов
    {
        if (ReadyRoad[0].transform.localPosition.z < maxsimumPositionZ)// если позиция готовой дороги с номером 0 меньше максимальной позиции 
        {
            int i;
            i = ReadyRoad[0].GetComponent<Road>().numberC; // присваеваем значение номера с готового объекта с номером 0
            roadNumbers[i] = false;// меняем статус с номером i
            ReadyRoad[0].transform.localPosition = waitingZona;//готовую дорогу с номером мы перемещаем в зону ожидания
            ReadyRoad.RemoveAt(0);//удаляем готовые объекты с номером 0 
            currentRoadLenght--;// уменьшаем текущую длину дороги объектов
        }
    }

    void RoadCreation()//метод генерации объектов
    {
        if (ReadyRoad.Count > 0) //если длина массива готовых объектов больше нуля
        {
            Road[currentRoadNumder].transform.localPosition = ReadyRoad[ReadyRoad.Count - 1].transform.position + new Vector3(0f, 0f, distanceDetweenRoads);// перемещаем в позицию предыдущей готовой дороги + вектор с дистанцией(по z)
        }
        else if (ReadyRoad.Count == 0) //если длина массива готовых объектов равна нулю
        {
            Road[currentRoadNumder].transform.localPosition = new Vector3(0f, 0f, 0f);//перемещаем в нулевые координаты объект с текущем номером
        }

        Road[currentRoadNumder].GetComponent<Road>().numberC = currentRoadNumder;// объектам с текущем номером присваеваем значение переменной номеру текущий номер дороги

        roadNumbers[currentRoadNumder] = true; // менаем статус у текущего объекта на истина(т е занят)

        LastRoadNumder = currentRoadNumder;//последнему номеру присваеваем тикущий номер

        ReadyRoad.Add(Road[currentRoadNumder]);//в массив готовых объектов добавляем объект с текущим номером

        currentRoadLenght++;//увеличиваем текущую длину дороги объектов
    }

}
