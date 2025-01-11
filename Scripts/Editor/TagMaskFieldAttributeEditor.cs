using DeadPilotTools.PoolSystem.runtime;
using UnityEditor;
using UnityEngine;

namespace DeadPilotTools.PoolSystem.editor
{
    [CustomPropertyDrawer(typeof(TagMaskFieldAttribute))]
    public class TagMaskFieldAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}
