using UnityEngine;
using uLipSync;

public class BakedDataTest : MonoBehaviour
{
    public GameObject lipSyncComp;
    public BakedData s1, s2, s3, s4, s5;
    public uLipSyncBakedDataPlayer bakedPlayer;


    void Start()
    {
        if(bakedPlayer == null){
            bakedPlayer = lipSyncComp.GetComponent<uLipSyncBakedDataPlayer>();
        }   
    }

    public void PlayBakedData(int index)
    {
        switch (index)
        {
            case 1:
                bakedPlayer.Play(s1);
                break;
            case 2:
                bakedPlayer.Play(s2);
                break;
            case 3:
                bakedPlayer.Play(s3);
                break;
            case 4:
                bakedPlayer.Play(s4);
                break;
            case 5:
                bakedPlayer.Play(s5);
                break;
        }
    }
}
