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
        if (this.map[location_x + location_y * 30].ContainsKey("road") && building_type == "building")
        {
            return;
        }
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
        // upgrade water_station
        if (this.map[location_x + location_y * 30].ContainsValue("water_station_lv1"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "water_station_lv2");
        }
        else if (this.map[location_x + location_y * 30].ContainsValue("water_station_lv2"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "water_station_lv3");
        }

        // upgrade house
        else if (this.map[location_x + location_y * 30].ContainsValue("house_lv1"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "house_lv2");
        }
        else if (this.map[location_x + location_y * 30].ContainsValue("house_lv2"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "house_lv3");
        }

        // upgrade factory
        else if (this.map[location_x + location_y * 30].ContainsValue("factory_lv1"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "factory_lv2");
        }
        else if (this.map[location_x + location_y * 30].ContainsValue("factory_lv2"))
        {
            remove_bulding(location_x, location_y, "building");
            add_bulding(location_x, location_y, "building", "factory_lv3");
        }

        // upgrade nothing
        else
        {
            return;
        }
    }

    void set_tile(int location_x, int location_y, string tile_type)
    {
        if (this.map[location_x + location_y * 30].ContainsKey("tile"))
        {
            this.map[location_x + location_y * 30].Remove("tile");
        }
        this.map[location_x + location_y * 30].Add("tile", tile_type);
    }

    void create_map()
    {
        for (int i = 0; i < this.map.Count; i++)
        {
            if (13 <= (i % 30) || (i % 30) <= 16 || 270 <= (i % 899) || (i % 900) <= 359)
            {
                set_tile(i % 30, i / 30, "water");
            }
            else
            {
                set_tile(i % 30, i / 30, "ground");
            }
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
