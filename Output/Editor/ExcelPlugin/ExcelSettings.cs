///////////////////////////////////////////////////////////////////////////////
///
/// ExcelSettings.cs
/// 
/// (c)2015 Kim, Hyoun Woo
///
///////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

namespace UnityQuickSheet
{
    /// <summary>
    /// A class manages excel setting.
    /// </summary>
    [CreateAssetMenu(menuName = "QuickSheet/Setting/Excel Setting")]
    public class ExcelSettings : SingletonScriptableObject<ExcelSettings>
    {
        private const string SDK_PRODUCT_NAME = "Unity-QuickSheet";
        private const string SDK_PACKAGE_NAME = "com.kimsama.quicksheet";

        /// <summary>
        /// A default path where .txt template files are.
        /// </summary>
        private string _templatePath = null;
        public string TemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(_templatePath))
                {
                    if (PlayerSettings.productName == SDK_PRODUCT_NAME)
                    {
                        _templatePath = "QuickSheet/ExcelPlugin/Templates";
                    }
                    else
                    {
                        _templatePath = "Packages/com.kimsama.quicksheet/Runtime/Templates/";
                    }
                }
                return _templatePath;
            }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    if (PlayerSettings.productName == SDK_PRODUCT_NAME)
                    {
                        _templatePath = "QuickSheet/ExcelPlugin/Templates";
                    }
                    else
                    {
                        _templatePath = "Packages/com.kimsama.quicksheet/Runtime/Templates/";
                    }
                }
                else
                    _templatePath = value;
            }
        }

        /// <summary>
        /// A path where generated ScriptableObject derived class and its data class script files are to be put.
        /// </summary>
        public string RuntimePath = string.Empty;

        /// <summary>
        /// A path where generated editor script files are to be put.
        /// </summary>
        public string EditorPath = string.Empty;

        /// <summary>
        /// Select currently exist account setting asset file.
        /// </summary>
        [MenuItem("Edit/QuickSheet/Select Excel Setting")]
        public static void Edit()
        {
            Selection.activeObject = Instance;
            if (Selection.activeObject == null)
            {
                Debug.LogError(@"No ExcelSetting.asset file is found. Create setting file first. See the menu at 'Create/QuickSheet/Setting/Excel Setting'.");
            }
        }
    }
}
