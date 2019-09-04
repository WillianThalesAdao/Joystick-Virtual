using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bala : MonoBehavior {

    // Use this for initialization
    void Start () {

    }

    // A atualização é chamada uma vez por quadro
    void Update () {
        transform.Translate (5 * Time.deltaTime, 0, 0);
    }
}