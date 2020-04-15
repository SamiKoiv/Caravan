using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

public class Editor_ItemDB : EditorWindow
{
    #region Properties

    public ItemDB DB;
    private List<Item> items;

    Vector2 itemScrollPosition;
    Item selectedItem;

    bool addingNewItem;

    int leftSideWidth = 350;
    int labelWidth = 100;
    int buttonWidth = 100;
    int itemDatafieldWidth = 200;

    int itemIdWidth = 50;
    int itemButtonWidth = 300;

    int filterOrderLabelWidth = 100;
    bool onlyUnfinished;

    #endregion

    #region GetPath

    private string GetPath(ItemDB itemDB) => AssetDatabase.GetAssetPath(itemDB);
    private string GetPath(Item item)
    {
        string parentPath = GetPath(DB);
        string parentFolder = parentPath.Substring(0, parentPath.LastIndexOf('/'));
        string folderName = "Items";
        string itemName = $"{item.ID}_{item.Name}.asset";

        if (!AssetDatabase.IsValidFolder($"{parentFolder}/{folderName}"))
            AssetDatabase.CreateFolder(parentFolder, folderName);

        return $"{parentFolder}/{folderName}/{itemName}";
    }

    #endregion

    #region Show Window

    [MenuItem("Window/ItemDB")]
    public static void ShowWindow()
    {
        GetWindow<Editor_ItemDB>("ItemDB");
    }

    #endregion

    #region Main

    private void OnGUI()
    {
        GUILayout.Label("Item Database", EditorStyles.boldLabel);
        DB = EditorGUILayout.ObjectField(DB, typeof(ItemDB), true, GUILayout.Width(leftSideWidth)) as ItemDB;
        if (DB == null) return;

        items = DB.Items;

        ToolBar();
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        LeftColumn();
        RightColumn();
        GUILayout.EndHorizontal();
    }

    private void ToolBar()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(new GUIContent("Add Item"), GUILayout.Width(buttonWidth)))
        {
            addingNewItem = true;
            selectedItem = ScriptableObject.CreateInstance<Item>();
            selectedItem.TrySetID(DB.NextID);
        }

        if (GUILayout.Button(new GUIContent("Clear Empty"), GUILayout.Width(buttonWidth)))
            DB.ClearMissing();

        GUILayout.EndHorizontal();
    }

    #endregion

    #region Filters

    private Item.ItemType filterType;
    private string searchWord;

    private void Filter()
    {
        int labelWidth = filterOrderLabelWidth;
        int controlWidth = (int)((leftSideWidth - filterOrderLabelWidth) * 0.5f);

        GUILayout.BeginHorizontal();
        GUILayout.Label(new GUIContent("Filter "), GUILayout.Width(filterOrderLabelWidth));
        filterType = (Item.ItemType)EditorGUILayout.EnumPopup(filterType, GUILayout.Width((controlWidth)));
        searchWord = GUILayout.TextField(searchWord, GUILayout.Width(controlWidth));

        GUILayout.EndHorizontal();

        if (filterType != Item.ItemType.None)
            items = items.Where(x => x.Type == filterType).ToList();

        if (searchWord != null && searchWord != string.Empty)
            items = items.Where(x => x.Name.ToLower().Contains(searchWord.ToLower())).ToList();
    }

    private void OnlyUnfinished()
    {
        int labelWidth = filterOrderLabelWidth;
        int controlWidth = (int)((leftSideWidth - filterOrderLabelWidth) * 0.5f);

        GUILayout.BeginHorizontal();
        GUILayout.Label(new GUIContent("Only unfinished "), GUILayout.Width(filterOrderLabelWidth));
        onlyUnfinished = EditorGUILayout.Toggle(onlyUnfinished);

        GUILayout.EndHorizontal();

        if (onlyUnfinished)
            items = items.Where(x => x.IsUnfinished).ToList();
    }

    #endregion

    #region Order By

    OrderType orderType = OrderType.ID;
    OrderDirection orderDirection = OrderDirection.Ascending;

    public enum OrderType
    {
        ID,
        Name,
        Type
    }

    public enum OrderDirection
    {
        Ascending,
        Descending
    }

    private void Order()
    {
        int labelWidth = filterOrderLabelWidth;
        int controlWidth = (int)((leftSideWidth - filterOrderLabelWidth) * 0.5f);

        GUILayout.BeginHorizontal();
        GUILayout.Label(new GUIContent("Order by "), GUILayout.Width(filterOrderLabelWidth));
        orderType = (OrderType)EditorGUILayout.EnumPopup(orderType, GUILayout.Width(controlWidth));
        orderDirection = (OrderDirection)EditorGUILayout.EnumPopup(orderDirection, GUILayout.Width(controlWidth));
        GUILayout.EndHorizontal();

        switch (orderDirection)
        {
            case OrderDirection.Ascending:
                switch (orderType)
                {
                    case OrderType.ID:
                        items = items.OrderBy(x => x.ID).ToList();
                        break;

                    case OrderType.Name:
                        items = items.OrderBy(x => x.Name).ToList();
                        break;

                    case OrderType.Type:
                        items = items.OrderBy(x => x.Type).ToList();
                        break;
                }
                break;

            case OrderDirection.Descending:
                switch (orderType)
                {
                    case OrderType.ID:
                        items = items.OrderByDescending(x => x.ID).ToList();
                        break;
                    case OrderType.Name:
                        items = items.OrderByDescending(x => x.Name).ToList();
                        break;

                    case OrderType.Type:
                        items = items.OrderByDescending(x => x.Type).ToList();
                        break;
                }
                break;
        }

    }

    #endregion

    #region Left Column

    private void LeftColumn()
    {
        GUILayout.BeginVertical();
        Order();
        Filter();
        OnlyUnfinished();
        GUILayout.Space(10);

        itemScrollPosition = GUILayout.BeginScrollView(itemScrollPosition, GUILayout.Width(400));
        items.ForEach(x => ShowItemInfo(x));
        GUILayout.EndScrollView();

        GUILayout.EndVertical();
    }

    private void ShowItemInfo(Item item)
    {
        if (item == null)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(new GUIContent($"ID: -"), GUILayout.Width(itemIdWidth));
            GUILayout.Label("Missing item", GUILayout.Width(itemButtonWidth));

            GUILayout.EndHorizontal();

            return;
        }

        string itemName = item.Name != string.Empty ? item.Name : "[No name]";

        GUILayout.BeginHorizontal();

        GUILayout.Label(new GUIContent($"ID: {item.ID}"), GUILayout.Width(itemIdWidth));
        if (GUILayout.Button(new GUIContent(itemName), GUILayout.Width(itemButtonWidth)))
        {
            selectedItem = item;
            addingNewItem = false;
        }

        GUILayout.EndHorizontal();
    }

    #endregion

    #region Right Column

    private void RightColumn()
    {
        GUILayout.BeginVertical();

        if (selectedItem == null) return;

        IdField();
        NameField();
        TypeField();
        ValueField();
        IconField();

        GUILayout.Space(20);
        ItemToolbar();

        GUILayout.EndVertical();
    }

    private void IdField()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("ID: ", GUILayout.Width(labelWidth));
        GUILayout.Label($"{selectedItem.ID}");
        GUILayout.EndHorizontal();
    }

    private void NameField()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ", GUILayout.Width(labelWidth));
        selectedItem.SetName(GUILayout.TextField(selectedItem.Name, GUILayout.Width(itemDatafieldWidth)));
        GUILayout.EndHorizontal();
    }

    private void TypeField()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Type: ", GUILayout.Width(labelWidth));
        Item.ItemType newType = (Item.ItemType)EditorGUILayout.EnumPopup(selectedItem.Type, GUILayout.Width(itemDatafieldWidth));
        selectedItem.SetType(newType);

        GUILayout.EndHorizontal();
    }

    private void ValueField()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Value: ", GUILayout.Width(labelWidth));

        string itemValueString = selectedItem.Value != 0 ? selectedItem.Value.ToString() : string.Empty;
        string valueString = GUILayout.TextField(itemValueString, GUILayout.Width(itemDatafieldWidth));
        int newValue;

        if (int.TryParse(valueString, out newValue))
            selectedItem.SetValue(newValue);
        else
            selectedItem.SetValue(0);

        GUILayout.EndHorizontal();
    }

    private void IconField()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Icon: ", GUILayout.Width(labelWidth));

        GUILayout.BeginVertical();

        var icon = EditorGUILayout.ObjectField(selectedItem.Icon, typeof(Sprite), true, GUILayout.Width(itemDatafieldWidth)) as Sprite;
        selectedItem.SetIcon(icon);

        if (icon != null)
            GUILayout.Box(icon.texture);

        GUILayout.EndVertical();


        GUILayout.EndHorizontal();
    }

    private void ItemToolbar()
    {
        GUILayout.BeginHorizontal();

        if (addingNewItem)
            if (GUILayout.Button("Save Item", GUILayout.Width(buttonWidth)))
            {
                AssetDatabase.CreateAsset(selectedItem, GetPath(selectedItem));
                DB.AddItem(selectedItem);
                addingNewItem = false;
                AssetDatabase.SaveAssets();
                AssetDatabase.ForceReserializeAssets(new string[] { GetPath(DB) }, ForceReserializeAssetsOptions.ReserializeAssetsAndMetadata);
            }

        if (!addingNewItem)
            if (GUILayout.Button("Delete Item", GUILayout.Width(buttonWidth)))
            {
                int index = DB.Items.IndexOf(selectedItem);
                int nextIndex = Math.Max(index - 1, 0);

                DB.DeleteItem(selectedItem);
                AssetDatabase.DeleteAsset(GetPath(selectedItem));
                AssetDatabase.ForceReserializeAssets(new string[] { GetPath(DB) }, ForceReserializeAssetsOptions.ReserializeAssetsAndMetadata);

                if (DB.Items.Count > 0)
                    selectedItem = DB.Items[nextIndex];
            }

        GUILayout.EndHorizontal();
    }

    #endregion

}
