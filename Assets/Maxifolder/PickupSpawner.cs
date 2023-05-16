using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Hacer ruleta de probabilidad para el droprate del loot
    private Roulette _roulette;
    [SerializeField] private Pickup pickupPrefab;
    [SerializeField] private LootTableSO lootTableSO;
    [SerializeField] private int dropsAmount;

    private Pickup _buffer;
    private float _timer = 2f;

    private void Awake()
    {
        lootTableSO.BuildTable();
        _roulette = new Roulette();
    }

    private void Update()
    {
        if (_buffer == null)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                SpawnPickups();
            }
        }
    }

    [ContextMenu("Spawn Pickups")]
    private void SpawnPickups()
    {
        var t = transform;
        var pos = t.position;
        var rot = t.rotation;
        var i = 0;
        while (i < dropsAmount)
        {
            for (i = 0; i < dropsAmount; i++)
            {
                _buffer = Instantiate(pickupPrefab, pos, rot);
                _buffer.Setup((_roulette.Run(lootTableSO.DicDropChance)), 1);
            }
        }

        _timer = 2f;
    }
}