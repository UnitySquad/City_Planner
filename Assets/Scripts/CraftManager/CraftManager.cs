using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public const int max_map_size = 899;
    List<Dictionary<string, string>> map = new List<Dictionary<string, string>>(new Dictionary<string, string>[max_map_size + 1]);
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
        // map1
        for (int i = 0; i < this.map.Count; i++)
        {
            if (13 <= (i % 30) || (i % 30) <= 16 || 270 <= (i % max_map_size) || (i % max_map_size + 1) <= 359)
            {
                set_tile(i % 30, i / 30, "river");
            }
            else
            {
                set_tile(i % 30, i / 30, "ground");
            }
        }
        this.map[124].Add("building", "house_lv1");
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

    void update_state(int location_x, int location_y)
    {
        if(check_around(location_x, location_y, "elctric"))
        {
            this.map[location_x + (location_y * 30)].Add("electric", "");
        }
        else
        {
            this.map[location_x + (location_y * 30)].Remove("electric");
        }
        if (check_around(location_x, location_y, "water"))
        {
            this.map[location_x + (location_y * 30)].Add("water", "");
        }
        else
        {
            this.map[location_x + (location_y * 30)].Remove("water");
        }
    }

    bool check_around(int location_x, int location_y, string type)
    {
        if (location_x >= 29 && location_y >= 29)
        {
            if (this.map[location_x + (location_y * 30) - 1].ContainsKey(type) || this.map[location_x + (location_y * 30) - 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_x <= 0 && location_y >= 29)
        {
            if (this.map[location_x + (location_y * 30) + 1].ContainsKey(type) || this.map[location_x + (location_y * 30) - 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_x >= 29 && location_y <= 0)
        {
            if (this.map[location_x + (location_y * 30) - 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_x <= 0 && location_y <= 0)
        {
            if (this.map[location_x + (location_y * 30) + 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_x >= 29)
        {
            if (this.map[location_x + (location_y * 30) - 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 30].ContainsKey(type) || this.map[location_x + (location_y * 30) - 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_y >= 29)
        {
            if (this.map[location_x + (location_y * 30) - 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 1].ContainsKey(type) || this.map[location_x + (location_y * 30) - 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_x <= 0)
        {
            if (this.map[location_x + (location_y * 30) + 1].ContainsKey(type) || this.map[location_x + (location_y * 30) - 30].ContainsKey(type) || this.map[location_x + (location_y * 30) + 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else if (location_y <= 0)
        {
            if (this.map[location_x + (location_y * 30) - 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 1].ContainsKey(type) || this.map[location_x + (location_y * 30) + 30].ContainsKey(type))
            {
                return true;
            }
            else
                return false;
        }
        else 
            return false;
    }
}
