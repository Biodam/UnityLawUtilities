﻿using UnityEngine;

namespace LUT.Snippets
{
    public class ScreenshotUtil : Singleton<ScreenshotUtil>
    {
        [SerializeField]
        private int _screenshotNumber;

        [SearchableEnum.SearchableEnum]
        public KeyCode keyCode = KeyCode.P;

        [Header("Path")]
        [SerializeField]
        [ContextMenuItem("OpenPath", "OpenPath")]
        private string _path = "screenshot_";
        [SerializeField]
        private bool _usePersistentDataPath = false;
        void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                Capture();
            }
        }

        [EasyButtons.Button(EasyButtons.ButtonMode.EnabledInPlayMode)]
        [ContextMenu("Capture")]
        public void Capture()
        {
            string path;
            GetPath(out path);

            ScreenCapture.CaptureScreenshot(path);
            Debug.Log("screenshot was taken and saved to " + path);
            _screenshotNumber++;

        }


        public void GetPath(out string path)
        {
            path = "";
            if (_usePersistentDataPath)
            {
                path = Application.persistentDataPath + "/";
            }
            path += _path + _screenshotNumber + ".png";
        }
    }
}