using System;
using System.Collections;
using System.Collections.Generic;
using Task2.Glossary;

namespace Task2.Printer
{
    public interface IPrinter
    {
        void Print(Concordance concordance);
    }
}