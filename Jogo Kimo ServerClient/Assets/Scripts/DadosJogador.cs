using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System.Data;
using UnityEngine.SceneManagement;

public class DadosJogador : MonoBehaviour
{

    public InputField nomeJogador;
    public InputField idadeJogador;

    string nome = null;
    int idade = 0;
    string data_geracao = null;
    public static int id;

    // Use this for initialization
    void Start()
    {
        nomeJogador = GameObject.Find("jogadorinput").GetComponent<InputField>();
        idadeJogador = GameObject.Find("idadeinput").GetComponent<InputField>();

        ConectaBanco.cn.Open();
        ConectaBanco.sql = ConectaBanco.cn.CreateCommand();
        ConectaBanco.cn.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void salvaDados()
    {
        nome = nomeJogador.text;
        idade = System.Convert.ToInt32(idadeJogador.text);
        data_geracao = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        //salva nome
        ConectaBanco.cn.Open();
        ConectaBanco.sql.CommandText = "INSERT INTO dados (nome, idade, data_geracao) VALUES ('" + nome + "', " + idade + ", '" + data_geracao + "'); " +
                                       "SELECT rowid FROM dados WHERE data_geracao = '" + data_geracao + "' ";
        ConectaBanco.exec = ConectaBanco.sql.ExecuteReader();
        while (ConectaBanco.exec.Read())
        {
            id = ConectaBanco.exec.GetInt32(0);
        }

        //Debug.Log(id);

        //fecha conexoes
        ConectaBanco.cn.Close();
        ConectaBanco.exec.Close();
        ConectaBanco.sql.Dispose();

        SceneManager.LoadScene("Modulo_relatorio");
    }
}
