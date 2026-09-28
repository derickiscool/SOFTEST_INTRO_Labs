using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTEST_INTRO_Calculator;

public interface IFileReader
{
    string[] Read(string path);
}