using System.Collections;
using System.Collections.Generic;
using FireballMovement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonIDHolder : MonoBehaviour
{
    [SerializeField] Button button;
    public int levelID;
    public bool IsBossLevel;
    public GameObject fireball;
    [SerializeField] public MeshRenderer[] balls;

    public void SetButtonAesthetics(int level,bool ThisLevelBeaten, bool PreviousLevelBeaten, int LevelProductionCompleted){
        if (IsBossLevel){
            fireball.SetActive(true);
            Destroy(fireball.GetComponent<FireballHorizontalMovement>());
            Destroy(fireball.GetComponent<Rigidbody>());
            Destroy(fireball.GetComponent<CapsuleCollider>());
        } else {
            fireball.SetActive(false);
        }
        foreach (MeshRenderer ball in balls){
            if(ThisLevelBeaten){
                ball.material.SetColor("_EmissionColor", Color.green);
            } else {
                ball.material.SetColor("_EmissionColor", Color.red);
            }
            if(!PreviousLevelBeaten){ //if the level before is not beaten, lights are off.
                ball.material.SetColor("_EmissionColor", Color.black);
            }
            if(LevelProductionCompleted < level)
            {
                ball.material.SetColor("_EmissionColor", Color.black);
            }
            //Keep this here, otherwise level 1 goes dark.
            if(level == 1)
            {
                button.interactable = true;
                if (ThisLevelBeaten)
                {
                    ball.material.SetColor("_EmissionColor", Color.green);
                } else
                {
                    ball.material.SetColor("_EmissionColor", Color.red);
                }
            }
        }
        if(PreviousLevelBeaten & LevelProductionCompleted < level){
            button.interactable = true;
        } else {
            button.interactable = false;
        }



    }
    public void LoadLevel(){
        Levels.Load(levelID);
    }
}
