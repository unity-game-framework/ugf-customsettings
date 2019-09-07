using System.Collections.Generic;
using UnityEngine;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditorData : ScriptableObject
    {
        [SerializeField] private string m_name;
        [SerializeField] private Material m_material;
        [SerializeField] private LayerMask m_mask;
        [SerializeField] private bool m_state;
        [SerializeField] private List<Vector4> m_list = new List<Vector4>();
        [SerializeField] private List<Quaternion> m_list2 = new List<Quaternion>();

        public string Name { get { return m_name; } set { m_name = value; } }
        public Material Material { get { return m_material; } set { m_material = value; } }
        public LayerMask Mask { get { return m_mask; } set { m_mask = value; } }
        public bool State { get { return m_state; } set { m_state = value; } }
        public List<Vector4> List { get { return m_list; } }
        public List<Quaternion> List2 { get { return m_list2; } }
    }
}
