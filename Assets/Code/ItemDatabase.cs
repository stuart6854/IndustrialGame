using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase {

    private static readonly Dictionary<string, Item> database = new Dictionary<string, Item>();

    private static readonly string Items_Json_File = "Json/Items";

    public static Item GetItem(string _itemSlug, int _amnt = 0) {
        Item item = database[_itemSlug];

        return new Item(item, _amnt);
    }

    public static void InitDatabase() {
        database.Clear();

        Debug.Log("ItemDatabase -> Loading Items!");

        TextAsset itemDB = Resources.Load<TextAsset>(Items_Json_File);
        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(itemDB.text);

        Debug.Log("ItemDatabase -> Loaded " + items.Count + " items.");

        foreach(Item item in items) {
            database.Add(item.itemSlug, item);
        }
    }

}
