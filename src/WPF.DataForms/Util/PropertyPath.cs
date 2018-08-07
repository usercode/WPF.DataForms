using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WPF.DataForms
{
    /// <summary>
    /// PropertyPathVisitor
    /// </summary>
    public class PropertyPath
    {
        public static string GetPropertyPath(Expression expression, String delimiter = ".")
        {
            if (expression == null)
            {
                return null;
            }

            PropertyPathVisitor propertyPathVisitor = new PropertyPathVisitor();

            propertyPathVisitor.Visit(expression);

            return propertyPathVisitor.Stack
                .Aggregate(
                    new StringBuilder(),
                    (sb, name) =>
                        (sb.Length > 0 ? sb.Append(delimiter) : sb).Append(name))
                .ToString();
        }
    }

    class PropertyPathVisitor : ExpressionVisitor
    {
        public PropertyPathVisitor()
        {
            Stack = new Stack<string>();
        }

        public Stack<String> Stack { get; }

        protected override Expression VisitMember(MemberExpression expression)
        {
            Stack.Push(expression.Member.Name);

            return base.VisitMember(expression);
        }

    }

}
