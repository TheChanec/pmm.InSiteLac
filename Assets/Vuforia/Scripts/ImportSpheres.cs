﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ImportSpheres : MonoBehaviour
{
    private List<GameObject> sphereList;
    public GameObject content;
    

    public IEnumerator DownloadSpheres()
    {
        // Pull down the JSON from our web-service
        WWW w = new WWW("https://serverpmi.tr3sco.net/api/KPIs");
        yield return w;

        print("Waiting for sphere definitions\n");

        // Add a wait to make sure we have the definitions
        yield return new WaitForSeconds(1f);
        print("Received sphere definitions\n");
        print(w.text);
        // Extract the spheres from our JSON results
        ExtractSpheres(w.text);

    }


    void Start()
    {
        sphereList = new List<GameObject>();
        //print("Started sphere import...\n");
        //StartCoroutine(DownloadSpheres());
    }

    public void Iniciar()
    {
        print("Started sphere import...\n");
        StartCoroutine(DownloadSpheres());
    }



    void ExtractSpheres(string json)
    {
        string json2 = "{\"valores\":" + json + "}";
        var items = KPICollection.CreateFromJSON(json2);

        //float x = 0, y = -0.01f, z = 0, r = 0.03f;
        float x = 0.79f, y = 0.05f, z = -1.476f, r = 0.03f;
        //x = -(0.06f * ((items.valores.Count / 2)));
        int columna = 0;

        Vector3 v = new Vector3(x, y, z);

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        sphere.transform.SetParent(content.gameObject.transform, false);
        //float float_YTD = Convert.ToSingle(item.YTD);
        //sphere.transform.position = new Vector3(x, y + (float_YTD / 2), z);
        sphere.transform.position = content.gameObject.transform.position;



        //x = x + (2 * (r + 0.002f));
        float d = 2 * r;

        //sphere.transform.localScale = new Vector3(d, d + float_YTD, d);
        sphere.transform.localScale = new Vector3(d, d, d);

        UnityEngine.Color col = UnityEngine.Color.white;
        switch (columna)
        {
            case 1:
                col = UnityEngine.Color.red;
                break;
            case 2:
                col = UnityEngine.Color.yellow;
                break;
            case 3:
                col = UnityEngine.Color.green;
                break;
            case 4:
                col = UnityEngine.Color.cyan;
                break;
            case 5:
                col = UnityEngine.Color.magenta;
                break;
            case 6:
                col = UnityEngine.Color.blue;
                break;
            case 7:
                col = UnityEngine.Color.grey;
                columna = 0;
                break;
        }

        sphere.GetComponent<Renderer>().material.color = col;



        //foreach (var item in items.valores)
        //{
        //    columna++;
        //    Vector3 v = new Vector3(x, y, z);

        //    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    sphere.transform.parent = content.gameObject.transform;
        //    //float float_YTD = Convert.ToSingle(item.YTD);
        //    //sphere.transform.position = new Vector3(x, y + (float_YTD / 2), z);
        //    sphere.transform.position = new Vector3(x, y , z);



        //    //x = x + (2 * (r + 0.002f));
        //    float d = 2 * r;

        //    //sphere.transform.localScale = new Vector3(d, d + float_YTD, d);
        //    sphere.transform.localScale = new Vector3(d, d , d);

        //    UnityEngine.Color col = UnityEngine.Color.white;
        //    switch (columna)
        //    {
        //        case 1:
        //            col = UnityEngine.Color.red;
        //            break;
        //        case 2:
        //            col = UnityEngine.Color.yellow;
        //            break;
        //        case 3:
        //            col = UnityEngine.Color.green;
        //            break;
        //        case 4:
        //            col = UnityEngine.Color.cyan;
        //            break;
        //        case 5:
        //            col = UnityEngine.Color.magenta;
        //            break;
        //        case 6:
        //            col = UnityEngine.Color.blue;
        //            break;
        //        case 7:
        //            col = UnityEngine.Color.grey;
        //            columna = 0;
        //            break;
        //    }

        //    sphere.GetComponent<Renderer>().material.color = col;



        //    sphereList.Add(sphere);
        //}



    }

    public void EliminarSphere()
    {
        foreach (var item in sphereList)
        {
            Destroy(item);
        }

    }

    void Update()

    {

    }

}