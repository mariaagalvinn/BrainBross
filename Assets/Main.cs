using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject CurrentCube;
    public GameObject LastCube;
    public Text Text;
    public int Level;
    public bool Done;
    public float SpeedFactor = 1.0f;
    private static readonly int Color1 = Shader.PropertyToID("_Color");

    public int nivel = 1;

    void Start()
    {
        NewBlock();
    }

    private void NewBlock()
    {
        if (LastCube != null)
        {
            CurrentCube.transform.position = new Vector3(
                Mathf.Round(CurrentCube.transform.position.x),
                CurrentCube.transform.position.y,
                Mathf.Round(CurrentCube.transform.position.z)
            );
            CurrentCube.transform.localScale = new Vector3(
                LastCube.transform.localScale.x - Mathf.Abs(CurrentCube.transform.position.x - LastCube.transform.position.x),
                LastCube.transform.localScale.y,
                LastCube.transform.localScale.z - Mathf.Abs(CurrentCube.transform.position.z - LastCube.transform.position.z)
            );
            CurrentCube.transform.position = Vector3.Lerp(CurrentCube.transform.position, LastCube.transform.position, 0.5f) + Vector3.up * 5f;

            if (CurrentCube.transform.localScale.x <= 0f || CurrentCube.transform.localScale.z <= 0f)
            {
                Done = true;
                if (Level >= 20)
                {
                    Text.text = $"[FIN] Puntos: {Level} bloques apilados";
                    StartCoroutine(NextScene());
                }
                else
                {
                    StartCoroutine(RestartScene());
                }
                return;
            }
        }

        LastCube = CurrentCube;
        CurrentCube = Instantiate(LastCube);
        CurrentCube.name = Level.ToString();
        CurrentCube.GetComponent<MeshRenderer>().material.SetColor(Color1, Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        Level++;
        Camera.main.transform.position = CurrentCube.transform.position + new Vector3(100, 70f, -100);
        Camera.main.transform.LookAt(CurrentCube.transform.position + Vector3.down * 30f);
        if (!Done)
        {
            UpdateScoreText();
        }
    }

    void Update()
    {
        if (Done) return;

        float time = Mathf.Abs((Time.realtimeSinceStartup * SpeedFactor) % 2f - 1f);
        Vector3 pos1 = LastCube.transform.position + Vector3.up * 10f;
        Vector3 pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;

        CurrentCube.transform.position = Vector3.Lerp(Level % 2 == 0 ? pos2 : pos1, Level % 2 == 0 ? pos1 : pos2, time);

        if (Input.GetMouseButtonDown(0))
            NewBlock();
    }

    private void UpdateScoreText()
    {
        Text.text = $"Puntos: {Level} bloques apilados";
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3f);
        switch (nivel)
        {
            case 1:
                SceneManager.LoadScene("Stack1");
                break;
            case 2:
                SceneManager.LoadScene("Stack2");
                break;
            case 3:
                SceneManager.LoadScene("Stack3");
                break;
        }
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);
        switch (nivel)
        {
            case 1:
                SceneManager.LoadScene("Stack2");
                break;
            case 2:
                SceneManager.LoadScene("Stack3");
                break;
            case 3:
                SceneManager.LoadScene("Mapa 5");
                break;
        }
    }
}
