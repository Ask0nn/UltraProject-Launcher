﻿using System;
using System.Collections.Generic;
using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Image
    {
        private string _path;

        public string Path { get => GetFullPathToImage(); set => _path = value; }
        public ImageType Type { get; set; }

        public Image(string path, ImageType type)
        {
            Path = path;
            Type = type;
        }

        private string GetFullPathToImage()
            => Type.Equals(ImageType.FILE) ? System.IO.Path.Combine(Environment.CurrentDirectory, _path) : _path; 
    }

    public enum ImageType
    {
        FILE,
        URL
    }
}
