using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PdfSharp;
using System.IO;
using System;
using UnityEngine.UI;

public class gerarpdf : MonoBehaviour
{
    string caminho;
    int ylinha = 200;
    InputField txtNome;
    InputField txtIdade;
    InputField txtPontuacaoMax;
    InputField txtPontuacaoMin;
    InputField txtPontuacao;
    Button btnAlterna;
    Text txtAlterna;

    // Start is called before the first frame update
    void Start()
    {
        txtNome = GameObject.Find("txtNome").GetComponent<InputField>();
        txtIdade = GameObject.Find("txtIdade").GetComponent<InputField>();
        txtPontuacaoMin = GameObject.Find("txtPontuacaoMin").GetComponent<InputField>();
        txtPontuacaoMax = GameObject.Find("txtPontuacaoMax").GetComponent<InputField>();
        txtPontuacao = GameObject.Find("txtPontuacao").GetComponent<InputField>();
        btnAlterna = GameObject.Find("btnAlterna").GetComponent<Button>();
        txtAlterna = GameObject.Find("txtbutton").GetComponent<Text>();

        txtAlterna.text = "Alternar para valor unico";
        txtPontuacao.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gerarfiltrado()
    {
        string nome = txtNome.text;
        string idade = txtIdade.text;

        using (var doc = new PdfSharp.Pdf.PdfDocument())
        {
            caminho = Application.dataPath + "/dados.csv";
            var page = doc.AddPage();
            var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
            var titulo = new PdfSharp.Drawing.XFont("Arial", 14, PdfSharp.Drawing.XFontStyle.Bold);
            var titulo2 = new PdfSharp.Drawing.XFont("Arial", 12, PdfSharp.Drawing.XFontStyle.Bold);
            var texto = new PdfSharp.Drawing.XFont("Arial", 12, PdfSharp.Drawing.XFontStyle.Regular);
            var letramiuda = new PdfSharp.Drawing.XFont("Arial", 8, PdfSharp.Drawing.XFontStyle.Regular);

            //data
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), letramiuda, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(5, 5, page.Width, page.Height));

            //titulo
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
            textFormatter.DrawString("Relatório de jogadores", titulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(0, 40, page.Width, page.Height));

            //logo em breve

            //titulos
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString("Nome:", titulo2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, 100, page.Width, page.Height));          //55
            textFormatter.DrawString("Idade:", titulo2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, 100, page.Width, page.Height));        //201
            textFormatter.DrawString("Pontuação:", titulo2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, 100, page.Width, page.Height));    //327
            //textFormatter.DrawString("Tempo:", titulo2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, 100, page.Width, page.Height));        //453

            string arquivo = File.ReadAllText(caminho);
            string[] linhas = arquivo.Split("\n"[0]);
            for (int i = 0; i < linhas.Length; i++)
            {
                if (i == 0)
                {
                    ylinha = 200;
                }

                string[] colunas = linhas[i].Split(","[0]);

                if(txtAlterna.text == "Alternar para valor unico")
                {
                    if(nome != "" && idade != "" && txtPontuacaoMin.text != "" && txtPontuacaoMax.text != "")
                    {
                        if(colunas[0].ToLower().StartsWith(nome.ToLower()) && idade == colunas[1] && int.Parse(txtPontuacaoMin.text) <= int.Parse(colunas[2]) && int.Parse(txtPontuacaoMax.text) >= int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if (nome != "" && idade != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()) && idade == colunas[1])
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if (nome != "" && txtPontuacaoMin.text != "" && txtPontuacaoMax.text != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()) && int.Parse(txtPontuacaoMin.text) <= int.Parse(colunas[2]) && int.Parse(txtPontuacaoMax.text) >= int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if(idade != "" && txtPontuacaoMin.text != "" && txtPontuacaoMax.text != "")
                    {
                        if (idade == colunas[1] && int.Parse(txtPontuacaoMin.text) <= int.Parse(colunas[2]) && int.Parse(txtPontuacaoMax.text) >= int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if (nome != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if (idade != "")
                    {
                        if (idade == colunas[1])
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else if (txtPontuacaoMin.text != "" && txtPontuacaoMax.text != "")
                    {
                        if (int.Parse(txtPontuacaoMin.text) <= int.Parse(colunas[2]) && int.Parse(txtPontuacaoMax.text) >= int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;

                        }
                    }
                    else
                    {
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));
                        ylinha += 50;
                    }
                }
                if(txtAlterna.text == "Alternar para intervalo")
                {
                    if (nome != "" && idade != "" && txtPontuacao.text != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()) && idade == colunas[1] && int.Parse(txtPontuacao.text) == int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                                  //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (nome != "" && idade != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()) && idade == colunas[1])
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                   //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (nome != "" && txtPontuacao.text != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()) && int.Parse(txtPontuacao.text) == int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                        //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (idade != "" && txtPontuacao.text != "")
                    {
                        if (idade == colunas[1] && int.Parse(txtPontuacao.text) == int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                         //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (nome != "")
                    {
                        if (colunas[0].ToLower().StartsWith(nome.ToLower()))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                      //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (idade != "")
                    {
                        if (idade == colunas[1])
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                       //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else if (txtPontuacao.text != "")
                    {
                        if (int.Parse(txtPontuacao.text) == int.Parse(colunas[2]))
                        {
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                            textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                            textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                            textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                            ylinha += 50;                                                                                                                                        //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453
                        }
                    }
                    else
                    {
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));
                        textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));
                        ylinha += 50;
                    }
                }

                //textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                //textFormatter.DrawString(colunas[0], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(55, ylinha, page.Width, page.Height));          //55
                //textFormatter.DrawString(colunas[1], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(201, ylinha, page.Width, page.Height));        //201
                //textFormatter.DrawString(colunas[2], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(327, ylinha, page.Width, page.Height));    //327
                //textFormatter.DrawString(colunas[3], texto, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(453, ylinha, page.Width, page.Height));        //453

            }

            doc.Save("DadosJogadores.pdf");
            System.Diagnostics.Process.Start("DadosJogadores.pdf");
        }
    }

    public void botao()
    {
        if(txtAlterna.text == "Alternar para valor unico")
        {
            txtPontuacaoMax.interactable = false;
            txtPontuacaoMin.interactable = false;
            txtPontuacao.interactable = true;

            txtAlterna.text = "Alternar para intervalo";
        }
        else
        {
            txtPontuacao.interactable = false;
            txtPontuacaoMax.interactable = true;
            txtPontuacaoMin.interactable = true;

            txtAlterna.text = "Alternar para valor unico";
        }
    }
}
