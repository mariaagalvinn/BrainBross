using System.Collections;
using System.Collections.Generic;
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
    public float distanciaVista=1;
    int posicionZ;

    // Start is called before the first frame update
    void Start()
    {
        
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
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad*Time.deltaTime);
    }

    public void Avanzar()
    {
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
}
