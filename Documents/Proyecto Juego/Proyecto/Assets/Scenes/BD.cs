using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class BD : ScriptableObject {
    public enum Uso{equipable,consumible}
    [System.Serializable]
    public struct ObjetoInventario
    {
        public string nombre;
        public Sprite sprite;
        public Uso uso;
        public int limite;
        public string descripcion;
        public string funcion;
    }
    public ObjetoInventario[] baseDatos;
}