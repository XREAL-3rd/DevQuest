using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "EdibleItem", menuName = "SO/EdibleItems")]
public class EdibleItemData: ScriptableObject
{
    [Tooltip("item prefab")] 
    public GameObject prefab;
    
    [Tooltip("the amount of increasing speed when a player eats it")] 
    public float increasingSpeed;

    [Tooltip("vfx when the item is eaten")] 
    public ParticleSystem eatenEffect;
}
