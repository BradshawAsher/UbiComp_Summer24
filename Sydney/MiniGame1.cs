using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame1 : MonoBehaviour
{
   public int sceneBuildIndex;

   //Level Move zoned enter, if collider is player move to scene
   private void OnTriggerEnter2d(Collider2D other) {
        print("Trigger Entered");

        //See if the game object has a player component
        if(other.tag == "MC") {
            print("Switching scene to " + sceneBuildIndex);
            SceneManger.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
   }
}

