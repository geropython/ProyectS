using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Building> _buildingsToPlace;
    [SerializeField]
    private List<MapNode> _map;

    private List<Building> _keyBuildings;
    private List<Building> _normalBuildings;
    private List<City> _cities;

    // Start is called before the first frame update
    void Awake()
    {
        SortNodes();
        GenerateMap();
    }

    #region Metodos Privados
    
    private void GenerateMap()
    {
        PlaceKeyBuildings();
        PlaceNormalBuildings();
    }

    /// <summary>
    /// Ordeno los nodos dentro de las listas que corresponda cada uno.
    /// </summary>
    private void SortNodes()
    {
        foreach (var item in _buildingsToPlace)
        {
            if (item.Settings.IsKeyBuilding) _keyBuildings.Add(item);
            else _normalBuildings.Add(item);
        }
    }

    private void PlaceKeyBuildings()
    {
        while (_keyBuildings.Count > 0)
        {
            var building = _keyBuildings[_keyBuildings.Count];
            //Si el edificio puede repetirse en el mundo lo ubica la cantidad de veces que se configuro.
            if (building.Settings.IsRepeatableInWorld)
                for (int i = 0; i < building.Settings.AmountPerWorld; i++)
                    PlaceBuildingInWorld(building);
            //Sino se agrega por unica vez al mapa.
            else
                PlaceBuildingInWorld(building);
            
            //Una vez agregado el edificio la cantidad de veces correspondientes, lo saco de la lista y sigo con el resto.
            _keyBuildings.Remove(building);
        }
    }

    private void PlaceNormalBuildings()
    {
        while (_normalBuildings.Count > 0)
        {
            var building = _normalBuildings[_normalBuildings.Count];
            //Si el edificio puede repetirse en la ciudad lo ubica la cantidad de veces que se configuro en cada ciudad.
            if (building.Settings.IsRepeatableInCity)
                for (int i = 0; i < building.Settings.AmountPerCity; i++)
                    foreach (var item in _cities)
                        PlaceBuildingInCity(building, item);
            //Sino se agrega por unica vez a cada ciudad del mapa.
            else
                foreach (var item in _cities)
                    PlaceBuildingInCity(building, item);

            //Una vez agregado el edificio la cantidad de veces correspondientes, lo saco de la lista y sigo con el resto.
            _normalBuildings.Remove(building);
        }
    }

    /// <summary>
    /// Coloca un edificio en un lugar aleatorio del mapa.
    /// </summary>
    private void PlaceBuildingInWorld(Building building)
    {
        _cities.OrderBy(x => x.AmountOfKeyBuildings);
    }

    /// <summary>
    /// Coloca un edificio en un lugar aleatorio de una ciudad.
    /// </summary>
    private void PlaceBuildingInCity(Building building, City city)
    {
        _cities.OrderBy(x => x.AmountOfKeyBuildings);
    }
    #endregion
}
