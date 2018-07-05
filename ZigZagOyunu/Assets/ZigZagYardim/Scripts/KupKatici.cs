using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupKatici : MonoBehaviour {

    public GameObject kupPrefab;

    private void Start()
    {
        Invoke("CreateCube", 2); // Gecikmeli Çağırım 2 sn ye sonra oluşturur.
        InvokeRepeating("CreateCube", 2, 1); // Gecikmeli sürekli çağırım (ilki 2 sn ye sonra saniyede bir)
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go= Instantiate(kupPrefab); // Anlık nesne üretimi gerçekleştirir Instantiate

            go.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 1000); // Hareket İleri atıyor.

            Destroy(go, 2); //2 sn ye sonra küp yok olacaktır.
        }
       
    }
    void CreateCube()
    {
        GameObject go = Instantiate(kupPrefab); // Anlık nesne üretimi gerçekleştirir Instantiate

        go.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 1000); // Hareket İleri atıyor.

        Destroy(go, 2); //2 sn ye sonra küp yok olacaktır.
    }
}
