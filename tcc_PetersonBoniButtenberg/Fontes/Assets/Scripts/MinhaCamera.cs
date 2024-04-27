using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;

public class MinhaCamera : MeuModelo
{
    public JSONObject props = new JSONObject();

    public TMP_InputField nome;
    public TMP_InputField fov;
    public TMP_InputField near;
    public TMP_InputField far;
    public TMP_InputField[] posicaoCamera;
    public TMP_InputField[] lookAtCamera;
    public JSONObject getProps()
    {
        return props;
    }
    public void addProps()
    {
        props.Add("nome", nome.text);

        JSONArray posicao = new JSONArray();
        posicao.Add("x", posicaoCamera[0].text);
        posicao.Add("y", posicaoCamera[1].text);
        posicao.Add("z", posicaoCamera[2].text);
        props.Add("posicao", posicao);

        JSONArray lookAt = new JSONArray();
        lookAt.Add("x", lookAtCamera[0].text);
        lookAt.Add("y", lookAtCamera[1].text);
        lookAt.Add("z", lookAtCamera[2].text);
        props.Add("lookAt", lookAt);

        props.Add("fov", fov.text);
        props.Add("near", near.text);
        props.Add("far", far.text);

        JSONArray posPeca = new JSONArray();
        posPeca.Add("x", this.transform.position.x);
        posPeca.Add("y", this.transform.position.y);
        posPeca.Add("z", this.transform.position.z);
        props.Add("posPeca", posPeca);
    }
}