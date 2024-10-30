using System;
using System.Data;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChallengerController : MonoBehaviour
{

    public int dificuldade = 1;

    public (string, double, double) GerarDesafio()
    {
        (string expression, double result, double wrong) = GerarOperacao(dificuldade);
        return (expression, result, wrong);
    }
    private (string, double, double) GerarOperacao(int dificuldade)
    {
        string expressao;
        double resultado;
        double wrong;

        switch (dificuldade)
        {
            case 1:
                expressao = GerarExpressão(new char[] { '+', '-' }, 1, 16, false, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 16);
                break;

            case 2:
                expressao = GerarExpressão(new char[] { '+', '-' }, 1, 16, true, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 16);
                break;

            case 3:

                expressao = GerarExpressão(new char[] { '+', '-' }, 2, 16, true, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 16);
                break;

            case 4:
                expressao = GerarExpressão(new char[] { '+', '-', '*' }, 2, 16, false, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 50);
                break;

            case 5:
                expressao = GerarExpressão(new char[] { '+', '-', '*', '+', }, 3, 16, true, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 100);
                break;

            case 6:
                expressao = GerarExpressão(new char[] { '+', '-', '*', '*' }, 3, 30, true, dificuldade);
                resultado = CalcularExpressao(expressao);
                wrong = Random.Range(0, 500);
                break;

            default:
                throw new ArgumentException("Nível de dificuldade inválido.");
        }

        if (wrong == resultado)
        {

            if (dificuldade == 4)
            {
                wrong = Random.Range(0, 50);

            }

            if (dificuldade == 5)
            {
                wrong = Random.Range(0, 100);

            }

            if (dificuldade == 6)
            {
                wrong = Random.Range(0, 30);

            }
            else
            {
                wrong = Random.Range(0, 16);
            }

        }

        return (expressao, resultado, wrong);
    }

    public string GerarExpressão(char[] operacoes, int numeroDeOperaçoes, int maxNum, bool negativeNumbers, int dificuldade)
    {
        string expressao = "";
        int numero1, numero2;
        string operacao;
        int fisrtRangeNumber = 0;
        bool parentesis = false;

        if (negativeNumbers)
        {
            fisrtRangeNumber = -maxNum;
        }

        for (int i = 0; i < numeroDeOperaçoes; i++)
        {
            numero1 = Random.Range(fisrtRangeNumber, maxNum);
            operacao = EscolherOperacao(operacoes);
            parentesis = GerarBoolAleatorio();

            if (dificuldade > 2 && parentesis == true && !(i == numeroDeOperaçoes - 2))
            {
                numero2 = Random.Range(fisrtRangeNumber, maxNum);
                expressao += $"{numero1} {operacao} {numero2}";
                expressao = $"({expressao})";
            }
            else
            {
                expressao += $"{numero1} {operacao}";
            }


            if (i == numeroDeOperaçoes - 1)
            {

                numero2 = Random.Range(fisrtRangeNumber, maxNum);
                expressao += $"{numero2}";
            }

        }

        return expressao;
    }
    private string EscolherOperacao(char[] operacoes)
    {
        int index = Random.Range(0, operacoes.Length);
        return operacoes[index].ToString();
    }

    private double CalcularExpressao(string expressao)
    {
        DataTable table = new();
        table.Columns.Add("expressao", typeof(string), expressao);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expressao"]);
    }

    private bool GerarBoolAleatorio()
    {
        // Gera um número float aleatório entre 0.0 e 1.0 e compara com 0.5
        return Random.value > 0.5f;
    }
}
