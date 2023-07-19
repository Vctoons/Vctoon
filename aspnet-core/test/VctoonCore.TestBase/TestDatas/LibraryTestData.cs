﻿using System;
using System.Collections.Generic;
using VctoonCore.Libraries;

namespace VctoonCore.TestDatas;

public class LibraryTestData
{
    public static string Name { get; } = "MyComic";
    public static Guid Id { get; } = Guid.NewGuid();

    public static List<LibraryPath> Paths { get; } = new List<LibraryPath>()
    {
        new LibraryPath(Guid.NewGuid(), Id, $@"D:\Vctoon_Tests")
    };
}
