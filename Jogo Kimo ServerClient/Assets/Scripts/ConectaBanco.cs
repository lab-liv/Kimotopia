using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;

public class ConectaBanco : MonoBehaviour
{

    public static IDbCommand sql;
    public static IDataReader exec;
    public static string arq = "URI=file:" + Application.dataPath + "/DadosJogadores.db";
    public static IDbConnection cn = (IDbConnection) new SqliteConnection(arq);

    // Use this for initialization
    void Start()
    {
        //cn.Open();
        //sql = cn.CreateCommand();
        //cn.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
