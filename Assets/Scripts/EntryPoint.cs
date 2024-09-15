using GameEngine;
using GameEngine.Objects;
using GameEngine.Systems;
using UnityEngine;

//TODO: Удалить этот класс!
//Развернуть архитектуру на Zenject/VContainer/Custom
public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private UnitManager unitManager;

    [SerializeField]
    private ResourceService resourceService;
    
    private void Start()
    {
        unitManager.SetupUnits(FindObjectsOfType<Unit>());
        resourceService.SetResources(FindObjectsOfType<Resource>());
    }
}