using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Diana3 : MonoBehaviour
{
    public float velocidad = 40;
    public int cantidadDisparos = 10;
    public float duracionPartida = 10;
    public Text textoPuntuacionActual;
    public Text textoDisparosRestantes;
    public Text textoTiempoRestante;

    private int puntuacionActual;
    private Vector3[][] posiciones;
    private Coroutine corrutinaMovimientoActual;
    private float duracionActual;

    public delegate void textoPuntuacion(int puntuacion);
    public static event textoPuntuacion puntuacionActualizada;

    public delegate void textoDisparos(int disparos);
    public static event textoPuntuacion disparosActualizados;

    public delegate void textoTiempo(int puntuacion);
    public static event textoTiempo tiempoActualizado;

    // Start is called before the first frame update
    void Start()
    {
        puntuacionActual = 0;
        duracionActual = 0;

        puntuacionActualizada?.Invoke(puntuacionActual);
        disparosActualizados?.Invoke(cantidadDisparos);
        tiempoActualizado?.Invoke((int)(duracionPartida - duracionActual));

        EstablecerPatronesMovimiento();
        PatronMovimientoAleatorio();
    }

    // Update is called once per frame
    void Update()
    {
        if(puntuacionActual < 300 && cantidadDisparos > 0 && duracionActual < duracionPartida)
        {
            duracionActual += Time.deltaTime;
            tiempoActualizado?.Invoke((int)(duracionPartida - duracionActual));


            if(Input.GetMouseButtonDown(0))
            {
                cantidadDisparos--;
                disparosActualizados?.Invoke(cantidadDisparos);
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(rayo, out hit))
                {
                    int puntosImpacto = hit.collider.GetComponent<PuntuacionDiana>()?.puntosPorImpacto ?? 0;
                    puntuacionActual+= puntosImpacto;

                    if(puntosImpacto > 0) 
                    {   
                        PatronMovimientoAleatorio();
                        puntuacionActualizada?.Invoke(puntuacionActual);
                    }

                    if(puntosImpacto==25) StartCoroutine(GirarDiana());
                }
            }   
        }
         else
        {
            if(puntuacionActual >= 300)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Mapa");
            }
            else 
            {
                puntuacionActual = 0;
                duracionActual = 0;
                cantidadDisparos = 10;
                duracionPartida = 10;

                puntuacionActualizada?.Invoke(puntuacionActual);
                disparosActualizados?.Invoke(cantidadDisparos);
                tiempoActualizado?.Invoke((int)(duracionPartida - duracionActual));
            }           
        }

    }

    private void EstablecerPatronesMovimiento()
    {
        posiciones = new Vector3[5][];
        posiciones[0] = new Vector3[] {new Vector3(10,0,0), new Vector3(-10,0,0)};
        posiciones[1] = new Vector3[] {new Vector3(0,5,0), new Vector3(0,-5,0)};
        posiciones[2] = new Vector3[] {new Vector3(5,0,5), new Vector3(5,0,-5), new Vector3(-5,0,5), new Vector3(-5,0,-5)} ;
        posiciones[3] = new Vector3[] {new Vector3(10,0,0), new Vector3(-10,0,0), new Vector3(0,0,10)};
        posiciones[4] = new Vector3[] {new Vector3(10,0,0), new Vector3(10,0,20), new Vector3(-10,0,20), new Vector3(-10,0,0)};
    }

    private void PatronMovimientoAleatorio()
    {
        if(corrutinaMovimientoActual!=null) StopCoroutine(corrutinaMovimientoActual);
        corrutinaMovimientoActual = StartCoroutine(MoverEntrePuntos(posiciones[Random.Range(0, posiciones.Length)]));
    }

    IEnumerator MoverEntrePuntos(Vector3[] puntos)
    {
        if(puntos.Length <2 ) yield break;
        int indicesSiguientePunto = 0;
        Vector3 inicio = transform.position;

        while(true)
        {
            Vector3 destino = puntos[indicesSiguientePunto];
            transform.position = Vector3.MoveTowards(inicio, destino, velocidad*Time.deltaTime);
            if(Vector3.Distance(transform.position, destino)<0.1f)
            {
                inicio = destino;
                indicesSiguientePunto = ++indicesSiguientePunto % puntos.Length;
            }
            else inicio = transform.position;
            yield return null;
        }
    }

    IEnumerator GirarDiana()
    {
        for(int i=0; i<18; i++)
        {
            transform.Rotate(0f, 100f, 0f);
            yield return null;
        }
    }
}
