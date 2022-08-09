using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public static class PackageBuilder
{
    private static readonly List<Tuple<string, string>> COPY_FOLDER_LIST = new List<Tuple<string, string>>() {
            new Tuple<string, string>("QuickSheet/Runtime", "Runtime"),
            // new Tuple<string, string>("QuickSheet/Tests", "Tests"),
            new Tuple<string, string>("QuickSheet/Editor", "Editor"),
            new Tuple<string, string>("QuickSheet/Samples", "Samples~"),
            new Tuple<string, string>("QuickSheet/Doc", "Documentation~"),
            // new Tuple<string, string>("QuickSheet/Plugins", "Plugins"),
        };

    [MenuItem("QuickSheet/BuildPackage")]
    private static void BuildPackage()
    {
        Debug.Log("Copy files start.");
        foreach (Tuple<string, string> item in COPY_FOLDER_LIST)
        {
            FileUtil.DeleteFileOrDirectory("Output/" + item.Item2);
            FileUtil.CopyFileOrDirectory("Assets/" + item.Item1, "Output/" + item.Item2);
        }
        Debug.Log("Copy files done.");
    }
}
