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

    void add_bulding(int x, int y, string building_type, string building_name)
    {
        if (this.map[x + (y * 30)].ContainsKey("road") || this.map[x + (y * 30)].ContainsKey("building") && building_type == "building")
        {
            return;
        }
        if (x <= opened_map_size && y <= opened_map_size)
        {
            if(building_name == "water_station_lv1")
            {
                this.map[x + (y * 30)].Add("water", "5");
            }
            else if (building_name == "water_station_lv2")
            {
                this.map[x + (y * 30)].Add("water", "10");
            }
            else if (building_name == "water_station_lv3")
            {
                this.map[x + (y * 30)].Add("water", "15");
            }
            this.map[x + (y * 30)].Add(building_type, building_name);
            update_state(x, y);
        }
        else
        {
            return;
        }
    }

    void remove_bulding(int x, int y, string building_type)
    {
        if (x <= opened_map_size && y <= opened_map_size)
        {
            this.map[x + (y * 30)].Remove(building_type);
        }
        else
        {
            return;
        }
    }

    void upgrade_building(int x, int y)
    {
        // upgrade water_station
        if (this.map[x + (y * 30)].ContainsValue("water_station_lv1"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "water_station_lv2");
        }
        else if (this.map[x + (y * 30)].ContainsValue("water_station_lv2"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "water_station_lv3");
        }

        // upgrade house
        else if (this.map[x + (y * 30)].ContainsValue("house_lv1"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "house_lv2");
        }
        else if (this.map[x + (y * 30)].ContainsValue("house_lv2"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "house_lv3");
        }

        // upgrade factory
        else if (this.map[x + (y * 30)].ContainsValue("factory_lv1"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "factory_lv2");
        }
        else if (this.map[x + (y * 30)].ContainsValue("factory_lv2"))
        {
            remove_bulding(x, y, "building");
            add_bulding(x, y, "building", "factory_lv3");
        }

        // upgrade nothing
        else
        {
            return;
        }
    }

    void set_tile(int x, int y, string tile_type)
    {
        if (this.map[x + (y * 30)].ContainsKey("tile"))
        {
            this.map[x + (y * 30)].Remove("tile");
        }
        this.map[x + (y * 30)].Add("tile", tile_type);
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

    void update_state(int x, int y)
    {
        int tmp;

        // check electric
        if ((tmp = check_around(x, y, "elctric")) != -1)
        {
            this.map[x + (y * 30)].Add("electric", this.map[tmp]["electric"] + 1);
        }
        else
        {
            this.map[x + (y * 30)].Remove("electric");
        }

        // check water
        if ((tmp = check_around(x, y, "water")) != -1)
        {
            this.map[x + (y * 30)].Add("water", this.map[tmp]["water"] + 1);
        }
        else
        {
            this.map[x + (y * 30)].Remove("water");
        }
    }

    int check_around(int x, int y, string type)
    {
        int result;
        if (x >= 29 && y >= 29)
        {
            if (this.map[x + (y * 30) - 1].ContainsKey(type) || this.map[x + (y * 30) - 30].ContainsKey(type))
            {
                return 899;
            }
            else
                return -1;
        }
        else if (x <= 0 && y >= 29)
        {
            if (this.map[x + (y * 30) + 1].ContainsKey(type) || this.map[x + (y * 30) - 30].ContainsKey(type))
            {
                return 870;
            }
            else
                return -1;
        }
        else if (x >= 29 && y <= 0)
        {
            if (this.map[x + (y * 30) - 1].ContainsKey(type) || this.map[x + (y * 30) + 30].ContainsKey(type))
            {
                return 29;
            }
            else
                return -1;
        }
        else if (x <= 0 && y <= 0)
        {
            if (this.map[x + (y * 30) + 1].ContainsKey(type) || this.map[x + (y * 30) + 30].ContainsKey(type))
            {
                return 0;
            }
            else
                return -1;
        }
        else if (x >= 29)
        {
            if (this.map[x + (y * 30) - 1].ContainsKey(type))
            {
                return (x + (y * 30) - 1);
            }
            else if (this.map[x + (y * 30) + 30].ContainsKey(type))
            {
                return (x + (y * 30) + 30);
            }
            else if (this.map[x + (y * 30) - 30].ContainsKey(type))
            {
                return (x + (y * 30) - 30);
            }
            else
                return -1;
        }
        else if (y >= 29)
        {
            if (this.map[x + (y * 30) - 1].ContainsKey(type))
            {
                return (x + (y * 30) - 1);
            }
            else if (this.map[x + (y * 30) + 1].ContainsKey(type))
            {
                return (x + (y * 30) + 1);
            }
            else if (this.map[x + (y * 30) - 30].ContainsKey(type))
            {
                return (x + (y * 30) - 30);
            }
            else
                return -1;
        }
        else if (x <= 0)
        {
            if (this.map[x + (y * 30) + 1].ContainsKey(type))
            {
                return (x + (y * 30) + 1);
            }
            else if (this.map[x + (y * 30) + 30].ContainsKey(type))
            {
                return (x + (y * 30) + 30);
            }
            else if (this.map[x + (y * 30) - 30].ContainsKey(type))
            {
                return (x + (y * 30) - 30);
            }
            else
                return -1;
        }
        else if (y <= 0)
        {
            if (this.map[x + (y * 30) - 1].ContainsKey(type))
            {
                return (x + (y * 30) - 1);
            }
            else if (this.map[x + (y * 30) + 1].ContainsKey(type))
            {
                return (x + (y * 30) + 1);
            }
            else if (this.map[x + (y * 30) + 30].ContainsKey(type))
            {
                return (x + (y * 30) + 30);
            }
            else
                return -1;
        }
        else
            return -1;
    }
}
