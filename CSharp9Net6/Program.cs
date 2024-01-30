using CSharp9Net6;
using System;

// 1) Программы верхнего уровня
var arg1 = args[0];
var ivan = new Person("ivan", "ivanov");

// 3) record with
var oleg = ivan with { FirstName = "oleg" };

Console.WriteLine(ivan);
Console.WriteLine(oleg);