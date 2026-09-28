using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTEST_INTRO_Calculator;

public class FileReader : IFileReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}