using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPreFab;

    public static SpawnItem main;

    private void Awake()
    {
        main = this;
        InvokeRepeating("Spawn", 5.0f, 5.0f);
    }

    private void Spawn()
    {
        float x = Random.Range(-5, 5);
        float y = 2.0f;
        float z = Random.Range(10, 20);
        Vector3 pos = new Vector3(x, y, z);
        Quaternion quat = Quaternion.Euler(new Vector3(45, 45, 45));
        GameObject item = Instantiate(itemPreFab, pos, quat);
        Destroy(item, 5.0f);
    }
}
