using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesJogador : MonoBehaviour
{
    public GameObject bolaDeFogo;
    public Transform pontoBola;
    [SerializeField] float tempoDeDestruir = 0.5f;

    public float velocidadeBola = 600;
    public void BolaDeFogo()
    {
        GameObject bola = Instantiate(bolaDeFogo, pontoBola.position, Quaternion.identity);
        bola.GetComponent<Rigidbody>().AddForce(pontoBola.forward * velocidadeBola);
        Destroy(bola, tempoDeDestruir);
    }
}
