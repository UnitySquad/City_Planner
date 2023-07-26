using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// max_map_size : 900(30*30)
// index_of_map_size : (0 ~ 29) * (0 ~ 29) - 0 ~ 899

public class CraftManager : MonoBehaviour
{
    List<Dictionary<string, string>> map = new List<Dictionary<string, string>>(new Dictionary<string, string>[900]);
    int opened_map_size = 9;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.map.Count);
        Debug.Log(this.opened_map_size);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void add_bulding(int location_x, int location_y, string building_type, string building_name)
    {
        if (location_x <= opened_map_size && location_y <= opened_map_size)
        {
            this.map[location_x + location_y * 30].Add(building_type, building_name);
        }
        else
        {
            return;
        }
    }

    void remove_bulding(int location_x, int location_y, string building_type)
    {
        if (location_x <= opened_map_size && location_y <= opened_map_size)
        {
            this.map[location_x + location_y * 30].Remove(building_type);
        }
        else
        {
            return;
        }
    }

    void upgrade_building(int location_x, int location_y)
    {
        if (this.map[location_x + location_y * 30].ContainsValue("water_station_lv1"))
        {
            remove_bulding(location_x, location_y, "water");
            add_bulding(location_x, location_y, "water", "water_station_lv2");
        }
        else if (this.map[location_x + location_y * 30].ContainsValue("water_station_lv2"))
        {
            remove_bulding(location_x, location_y, "water");
            add_bulding(location_x, location_y, "water", "water_station_lv2");
        }
        else
        {
            return;
        }
    }

    void extend_map()
    {
        if (this.opened_map_size <= 9)
        {
            this.opened_map_size = 19;
            Debug.Log(this.opened_map_size);
        }
        else if (this.opened_map_size <= 19)
        {
            this.opened_map_size = 29;
            Debug.Log(this.opened_map_size);
        }
        else
        {
            Debug.Log("Can't extend map");
            return;
        }
    }

    void reset_map()
    {
        for (int i = 0; i < this.map.Count; i++)
        {
            this.map[i].Clear();
        }
    }
}
