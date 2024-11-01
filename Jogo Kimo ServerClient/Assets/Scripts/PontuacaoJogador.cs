using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System.Data;

public class PontuacaoJogador : MonoBehaviour
{

	public static string valor_nome;
	public static string valor_idade;
	public static string valor_pontuacao;
	public static string valor_tempo_total;

	public static string valor_tempo1;
	public static string valor_certos1;
	public static string valor_errados1;

	public static string valor_tempo2;
	public static string valor_certos2;

	public static string valor_tempo3;
	public static string valor_certos3;




    public Text txtNome;
    public Text txtIdade;
    public Text txtPontuacao;
	public Text txtTempoTotal;

	public Text txtTempo1;
	public Text txtCertos1;
	public Text txtErrado1;

	public Text txtTempo2;
	public Text txtCertos2;

	public Text txtTempo3;
	public Text txtCertos3;

    // Use this for initialization
    void Start()
    {
        /*txtNome = GameObject.Find("txtNome").GetComponent<Text>();
        txtIdade = GameObject.Find("txtIdade").GetComponent<Text>();
        txtPontuacao = GameObject.Find("txtPontuacao").GetComponent<Text>();

        ConectaBanco.cn.Open();
        ConectaBanco.sql = ConectaBanco.cn.CreateCommand();
        ConectaBanco.sql.CommandText = "UPDATE dados SET pontuacao = '" + GameController.pontuacao + "' WHERE rowid = " + DadosJogador.id + ";" +
                                       "SELECT * FROM dados WHERE rowid = " + DadosJogador.id;
        ConectaBanco.exec = ConectaBanco.sql.ExecuteReader();
        while (ConectaBanco.exec.Read())
        {
            nome = ConectaBanco.exec.GetString(0);
            idade = ConectaBanco.exec.GetInt32(1);
            pontuacao = ConectaBanco.exec.GetInt32(2);
        }

        ConectaBanco.cn.Close();
        ConectaBanco.exec.Close();
        ConectaBanco.sql.Dispose();
		*/


		valor_pontuacao = AtivaReplica.Instance.points.text;
		valor_nome = Valores_aplicador.Instance.nome;
		valor_idade = Valores_aplicador.Instance.idade;
		valor_tempo_total = AtivaReplica.Instance.tempo.text;

		valor_tempo1 = Valores_medicacao.Instance.tempo_medicacao;
		valor_certos1 = Valores_medicacao.Instance.certos_medicacao;
		valor_errados1 = Valores_medicacao.Instance.errados_medicacao;

		valor_tempo2 = Valores_alimentacao.Instance.tempo_alimentacao;
		valor_certos2 = Valores_alimentacao.Instance.certos_alimentacao;

		valor_tempo3 = Valores_higiene.Instance.tempo_higiene;
		valor_certos3 = Valores_higiene.Instance.certos_higiene;



		//Debug.Log (valor_tempo1+" "+valor_certos1+" "+valor_errados1);
		txtNome.text = valor_nome;
		txtIdade.text = valor_idade;
		txtPontuacao.text = valor_pontuacao;
		txtTempoTotal.text = valor_tempo_total;

		txtTempo1.text = valor_tempo1;
		txtCertos1.text = valor_certos1;
		txtErrado1.text = valor_errados1;

		txtTempo2.text = valor_tempo2;
		txtCertos2.text = valor_certos2;

		txtTempo3.text = valor_tempo3;
		txtCertos3.text = valor_certos3;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
