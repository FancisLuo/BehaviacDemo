using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class BehaviorTreeUtil
    {
        private static string filePath = "/Config";

        private static string exportedFilePath
        {
            get
            {
                if(RuntimePlatform.WindowsEditor == Application.platform || RuntimePlatform.WindowsPlayer == Application.platform)
                {
                    return Application.dataPath + filePath;
                }
                else
                {
                    return "Assets" + filePath;
                }
            }
        }

        public static void InitBT()
        {
            behaviac.Agent.RegisterInstanceName<NonPlayerCharacterAgent>();
            behaviac.Config.IsLogging = false;
            behaviac.Config.IsSocketing = false;

            string path = Application.streamingAssetsPath;

            //behaviac.Workspace.Instance.ExportMetas(metasPath/*"../../meta/demo_running.xml"*/);

            //behaviac.Workspace.Instance.FilePath = "../BehaviacDemoWorkspace/exported";
            behaviac.Workspace.Instance.FilePath = exportedFilePath;
            behaviac.Workspace.Instance.FileFormat = behaviac.Workspace.EFileFormat.EFF_xml;
        }
    }
}
