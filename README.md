# Caravan

This is a little resource management and free-flowing learning project of mine. Takes inspiration from games like Cities Skylines, Mindustry and Factorio.

Some features developed so far:
- Item base architecture is in place. The items are based on Unity's ScriptableObjects, which I can later quite easily serialize for save data.
- I created a custom item database editor to help me keep myself sane with the increasing amount of in-game items and resources.
- I have created first iteration for resource upgrading flow where you consume items to produce new items (like iron ore and coal to iron bars).

One point of interest that stands out for me is the Item management view I created. The view is written in functional programming that is more commonly seen in web development languages like React.
Link: https://github.com/sekopallo/Caravan/blob/master/Assets/Scripts/Items/Editor/Editor_ItemDB.cs
