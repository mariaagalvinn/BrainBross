using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public int carril;
    public int lateral;
    public Vector3 posObjetivo;
    public float velocidad;
    public Mundo mundo;
    public Transform grafico;
    public LayerMask capaObstaculos;
    public LayerMask capaAgua;
    public Animator animaciones;
    public AnimationCurve curva;
    public float distanciaVista=1;
    public bool vivo=true;
    int posicionZ;
    bool bloqueo = false;
    public float tazaIncremento;
    public float escalainicial = 0.8f;
    public Text ganado;
    private int saltos = 0;
    public Canvas ganar;
    public Canvas perder;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = escalainicial;
        InvokeRepeating("MirarAgua", 1, 0.5f);
        ganar.gameObject.SetActive(false);
        perder.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        comprobar();
        ActualizarPosicion();
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Avanzar();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        } 
        else if(Input.GetKeyDown(KeyCode.D))
        {
            MoverLados(1);
        } 
        else if(Input.GetKeyDown(KeyCode.A))
        {
            MoverLados(-1);
        } 
        if(!vivo && saltos <20)
        {
            Destroy(gameObject);
            perder.gameObject.SetActive(true);
        }
    }

    private void comprobar()
    {
        if(saltos==20)
        {
            //ganado.text = "Ha ganado";
            //SceneManager.LoadScene("Mapa");
            Destroy(gameObject);
            ganar.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(grafico.position+Vector3.one*0.5f, grafico.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(grafico.position+Vector3.one*0.5f, grafico.position+Vector3.one*0.5f + grafico.forward* distanciaVista);
    }

    public void ActualizarPosicion()
    {
        if(vivo==false)
        {
            return;
        }
        
    }

    public IEnumerator CambiarPosicion()
    {
        bloqueo = true;
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        Vector3 posActual = transform.position;
        for(int i=0; i<10;i++)
        {
            transform.position = Vector3.Lerp(posActual, posObjetivo, i*0.1f)+Vector3.up*curva.Evaluate(i*0.1f);
            yield return new WaitForSeconds(1f/velocidad);
        }

        transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad*Time.deltaTime);
        bloqueo =false;
    }

    public void Avanzar()
    {
        if(vivo==false || bloqueo==true)
        {
            return;
        }
        grafico.eulerAngles = Vector3.zero;
        if(MirarAdelante())
        {
            return; 
        }
        posicionZ++;
        if(posicionZ > carril)
        {
            carril=posicionZ;
            mundo.CrearPiso();
            Time.timeScale = escalainicial+tazaIncremento*carril;
            saltos++;
            ganado.text = "Carril actual: " + saltos; 
        }
        StartCoroutine(CambiarPosicion());
    }

    public void Retroceder()
    {
        if(vivo==false || bloqueo==true)
        {
            return;
        }
        grafico.eulerAngles = new Vector3(0, 180, 0);
        if(MirarAdelante())
        {
            return ;
        }
        posicionZ--;
       if(posicionZ < 0)
       {
            carril=posicionZ;
       }
       StartCoroutine(CambiarPosicion());
    }

    public void MoverLados(int cuanto)
    {
        if(vivo==false || bloqueo==true)
        {
            return;
        }
        grafico.eulerAngles = new Vector3(0, 90*cuanto, 0);
        if(MirarAdelante())
        {
            return ;
        }
        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -4, 4);
        StartCoroutine(CambiarPosicion());
    }

    public bool MirarAdelante()
    {
        RaycastHit hit;
        Ray rayo = new Ray (grafico.position + Vector3.up*0.5f, grafico.forward);

        if(Physics.Raycast(rayo, out hit, distanciaVista, capaObstaculos))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("carro"))
        {
            animaciones.SetTrigger("morir");
            vivo=false;
        }
    }

    public void MirarAgua()
    {
        RaycastHit hit;
        Ray rayo = new Ray (transform.position + Vector3.up, Vector3.down);
        if(Physics.Raycast(rayo, out hit, 1, capaAgua))
        {
            if(hit.collider.CompareTag("agua"))
            {
                animaciones.SetTrigger("agua");
                vivo = false;
            }
        }
    }
}
