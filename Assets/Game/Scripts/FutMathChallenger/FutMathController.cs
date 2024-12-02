using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FutMathController : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] TextMeshPro GoalTextD;
    [SerializeField] TextMeshPro GoalTextR;

    public GameObject[] Operations;


    public int ballNumbers = 10;
    private List<int> nums;
    private double resultado;
    private string expressao;

    private void Start()
    {
        (expressao, nums) = MathGen.GerarExpressão(new char[] { '+', '-', '*' }, 2, 9, false, 1);
        resultado = MathGen.Calculate(expressao);

        GoalTextD.text = resultado.ToString();
        GoalTextR.text = resultado.ToString();

        for (int i = 0; i < ballNumbers; i++)
        {

            int number = 0;

            if (i < nums.Count)
            {
                number = nums[i];
            }
            else
            {
                number = Random.Range(1, 10);
            }

            SpawnBalls(i, number);

        }

        for (int i = 0; i < Operations.Length; i++)
        {
            SpawnOperations(i);
        }
    }
    public void SpawnBalls(int id, int value)
    {
        int spawnPointX = Random.Range(17, 80);
        int spawnPointZ = Random.Range(0, 72);
        int spawnPointY = 1;

        Vector3 spawnPosition = new(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(ball, spawnPosition, Quaternion.identity);

        // ball.transform.GetChild(0).GetChild(0).GetComponent<BallColliderController>().SetID(id);
        ball.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = value.ToString();

    }
    public void SpawnOperations(int index)
    {
        int spawnPointX = Random.Range(17, 80);
        int spawnPointZ = Random.Range(0, 72);
        int spawnPointY = 1;


        Vector3 spawnPosition = new(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(Operations[index], spawnPosition, Operations[index].transform.rotation);
    }
}
