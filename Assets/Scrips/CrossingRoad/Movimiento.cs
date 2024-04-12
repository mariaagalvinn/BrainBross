using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
    public float distanciaVista=1;
    public bool vivo=true;
    int posicionZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MirarAgua", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicion();
        if(Input.GetKeyDown(KeyCode.W))
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
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad*Time.deltaTime);
    }

    public void Avanzar()
    {
        if(vivo==false)
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
        }
    }

    public void Retroceder()
    {
        if(vivo==false)
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
    }

    public void MoverLados(int cuanto)
    {
        if(vivo==false)
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
                vivo = false;
            }
        }
    }
}
