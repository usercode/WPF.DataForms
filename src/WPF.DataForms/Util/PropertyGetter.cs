using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.DataForms
{
    public delegate Object PropertyGetter<T>(T obj);
    public delegate TResult PropertyGetter<T, TResult>(T obj);
}
