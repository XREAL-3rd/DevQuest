using UnityEngine;
using UnityEngine.Pool;

public class Bars : MonoBehaviour
{
    public static Bars Instance { get; private set; }
    [SerializeField] GameObject baseBar;
    ObjectPool<Fill> barPool;

    Bars()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        barPool = new(
            () => Instantiate(baseBar, transform).GetComponent<Fill>(),
            bar => bar.gameObject.SetActive(true),
            bar => bar.gameObject.SetActive(false),
            Destroy
        );
    }

    public static Fill GetBar()
    {
        return Instance.barPool.Get();
    }

    public static void ReleaseBar(Fill bar)
    {
        Instance.barPool.Release(bar);
    }
}