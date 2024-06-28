using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using UnityEngine.UI;
public class MinhaIluminacao : MeuModelo
{
    public JSONObject props = new JSONObject();

    //vou ter q repetir as props padr�o, pq l� na hierarquia n foi reaproveitado...

    public TMP_InputField nome;
    public TMP_Dropdown tipoLuz;

    [Header("Ambiente")]
    public TMP_InputField[] posicaoLuz;
    public Material cor;
    public Toggle ativo;

    [Header("Directional")]
    public TMP_InputField[] posicaoLuzDirect;
    public Material corDirect;
    public Toggle ativoDirect;
    public TMP_InputField intensidade;
    public TMP_InputField[] valores;

    [Header("Point")]
    public TMP_InputField[] posicaoLuzPoint;
    public Material corPoint;
    public Toggle ativoPoint;
    public TMP_InputField intPoint;
    public TMP_InputField distancia;

    [Header("Spot")]
    public TMP_InputField[] posicaoLuzSpot;
    public Material corSpot;
    public Toggle ativoSpot;
    public TMP_InputField intSpot;
    public TMP_InputField distSpot;
    public TMP_InputField angulo;
    public TMP_InputField expoente;
    public TMP_InputField[] valSpot;

    //� assim q pega o tipo da luz
    //tipoLuz.options[tipoLuz.value].text;
    public JSONObject getProps()
    {
        return props;
    }
    public void addProps(string nomePeca)
    {
        if (Global.propriedadePecas.ContainsKey(nomePeca))
        {
            //var luz = Global.propriedadePecas[nomePeca];
            props.Add("nome", "Iluminacao");
            string tipo = tipoLuz.options[tipoLuz.value].text;
            PropriedadePeca[] luz = new PropriedadePeca[4];
            foreach(KeyValuePair<string, PropriedadePeca[]> ilu in Global.propriedadeIluminacao)
            {
                if (nomePeca == ilu.Key) luz = ilu.Value;
            }
            props.Add("tipoLuz", tipo);
            PropriedadePeca luzinha = luz[0];
            switch (tipo)
            {
                case "Ambiente":
                    JSONArray posicao = new JSONArray();
                    if (luzinha != null)
                    {
                        posicao.Add("x", luzinha.Pos.X.ToString());
                        posicao.Add("y", luzinha.Pos.Y.ToString());
                        posicao.Add("z", luzinha.Pos.Z.ToString());
                        props.Add("posicao", posicao);

                        props.Add("cor", luzinha.Cor.ToString());
                        props.Add("ativo", luzinha.Ativo);
                    }
                    else
                    {
                        posicao.Add("x", posicaoLuz[0].text);
                        posicao.Add("y", posicaoLuz[1].text);
                        posicao.Add("z", posicaoLuz[2].text);
                        props.Add("posicao", posicao);

                        props.Add("ativo", ativo.enabled);
                    }
                    break;
                case "Directional":
                    luzinha = luz[1];
                    JSONArray posicao2 = new JSONArray();
                    if (luzinha != null)
                    {
                        posicao2.Add("x", luzinha.Pos.X.ToString());
                        posicao2.Add("y", luzinha.Pos.Y.ToString());
                        posicao2.Add("z", luzinha.Pos.Z.ToString());
                        props.Add("posicao", posicao2);

                        props.Add("cor", luzinha.Cor.ToString());
                        props.Add("ativo", luzinha.Ativo);
                    }
                    else
                    {
                        posicao2.Add("x", posicaoLuzDirect[0].text);
                        posicao2.Add("y", posicaoLuzDirect[1].text);
                        posicao2.Add("z", posicaoLuzDirect[2].text);
                        props.Add("posicao", posicao2);

                        props.Add("ativo", ativoDirect.enabled);
                    }
                    
                    props.Add("intensidade", intensidade.text);
                    JSONArray vals = new JSONArray();
                    vals.Add("x", valores[0].text);
                    vals.Add("y", valores[1].text);
                    vals.Add("z", valores[2].text);
                    props.Add("valores", vals);
                    break;
                case "Point":
                    luzinha = luz[2];
                    JSONArray posicao3 = new JSONArray();
                    if (luzinha != null)
                    {
                        posicao3.Add("x", luzinha.Pos.X.ToString());
                        posicao3.Add("y", luzinha.Pos.Y.ToString());
                        posicao3.Add("z", luzinha.Pos.Z.ToString());
                        props.Add("posicao", posicao3);

                        props.Add("cor", luzinha.Cor.ToString());
                        props.Add("ativo", luzinha.Ativo);
                    }
                    else
                    {
                        posicao3.Add("x", posicaoLuzPoint[0].text);
                        posicao3.Add("y", posicaoLuzPoint[1].text);
                        posicao3.Add("z", posicaoLuzPoint[2].text);
                        props.Add("posicao", posicao3);

                        props.Add("ativo", ativoDirect.enabled);
                    }
                    props.Add("intensidade", intPoint.text);
                    props.Add("distancia", distancia.text);
                    break;
                case "Spot":
                    luzinha = luz[3];
                    JSONArray posicao4 = new JSONArray();
                    if (luzinha != null)
                    {
                        posicao4.Add("x", luzinha.Pos.X.ToString());
                        posicao4.Add("y", luzinha.Pos.Y.ToString());
                        posicao4.Add("z", luzinha.Pos.Z.ToString());
                        props.Add("posicao", posicao4);

                        props.Add("cor", luzinha.Cor.ToString());
                        props.Add("ativo", luzinha.Ativo);
                    }
                    else
                    {
                        posicao4.Add("x", posicaoLuzSpot[0].text);
                        posicao4.Add("y", posicaoLuzSpot[1].text);
                        posicao4.Add("z", posicaoLuzSpot[2].text);
                        props.Add("posicao", posicao4);

                        props.Add("ativo", ativoDirect.enabled);
                    }
                    props.Add("intensidade", intSpot.text);
                    props.Add("distancia", distSpot.text);
                    props.Add("angulo", angulo.text);
                    props.Add("expoente", expoente.text);
                    JSONArray vals2 = new JSONArray();
                    vals2.Add("x", valSpot[0].text);
                    vals2.Add("y", valSpot[1].text);
                    vals2.Add("z", valSpot[2].text);
                    props.Add("valores", vals2);
                    break;
            }

            JSONArray posPeca = new JSONArray();
            posPeca.Add("x", this.transform.position.x);
            posPeca.Add("y", this.transform.position.y);
            posPeca.Add("z", this.transform.position.z);
            props.Add("posPeca", posPeca);
        }
        else
        {
            props.Add("nome", "Iluminacao");
            props.Add("tipoLuz", "Ambiente");

            JSONArray posicao = new JSONArray();
            posicao.Add("x", "100");
            posicao.Add("y", "300");
            posicao.Add("z", "0");
            props.Add("posicao", posicao);

            props.Add("ativo", true);

            JSONArray posPeca = new JSONArray();
            posPeca.Add("x", this.transform.position.x);
            posPeca.Add("y", this.transform.position.y);
            posPeca.Add("z", this.transform.position.z);
            props.Add("posPeca", posPeca);
        }
        /*
        if (props["posicao"][0].Count == 0)
        {
            JSONArray posicao = new JSONArray();
            posicao.Add("x", "100");
            posicao.Add("y", "300");
            posicao.Add("z", "0");
            props.Add("posicao", posicao);
        }
        */
        if (props["cor"] == null) props.Add("cor", "RGBA(1.000, 1.000, 1.000, 1.000)");
    }
}