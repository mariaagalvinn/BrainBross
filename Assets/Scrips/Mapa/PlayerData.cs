using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    [SerializeField] private int plataformaIndex;

    private void Awake()
    {
        if (PlayerData.Instance == null)
        {
            PlayerData.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlataforma(int index)
    {
        plataformaIndex = index;
    }

    public int GetPlataforma()
    {
        return plataformaIndex;
    }
}
