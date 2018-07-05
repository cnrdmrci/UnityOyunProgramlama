using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour {

    public float offset = 0.707f;
    public Vector3 lastPos;
    public GameObject wallPrefab;
    int counter;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void CreateNewWalls()
    {
        InvokeRepeating("CreateWalls", 1, 0.5f); // Tekrarlı çağırma 1 kere çağrıyor 0.5 sn ye de tekrar
    }
    private void CreateWalls()
    {
      //  float distance = Vector3.Distance(player.position,lastPos); // 2 Vektör arasındaki fark uzaklık
      // float ekranDikey = Camera.main.orthographicSize; //ekran büyüklüğü
       // if (distance > ekranDikey+2) return;  // Burdaki amaç Ekran genişlerken fazladan kutu çıkmasını önlemek için sınırlandırma

        int chance = Random.Range(0, 100);
        Vector3 newPos = Vector3.zero;

        if (chance < 50)

            newPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        else

            newPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);


        GameObject wall = Instantiate(wallPrefab, newPos, Quaternion.Euler(0, 45, 0), transform);

        lastPos = wall.transform.position;
        counter++;
        if(counter%Random.Range(3,5)==0) //3 ile 5 arasında elmas üret
        {
            wall.transform.GetChild(0).gameObject.SetActive(true); //elmas set et elmas koy
        }
    }
}
