using UnityEditor;
using UnityEngine;
using DeadPilotTools.PoolSystem.runtime;

namespace DeadPilotTools.PoolSystem.editor
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    public class LayerAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }
}