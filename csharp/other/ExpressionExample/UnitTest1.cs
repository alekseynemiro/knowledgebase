using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionExample
{

  [TestClass]
  public class UnitTest1
  {

    [TestMethod]
    public void CombinePredicates_Should_Avoid_Closure()
    {
      var value = 0;

      var iks = Expression.Parameter(typeof(int), "x");
      var v = Expression.Constant(value, typeof(int)); // фиксируем значение value 
      var less = Expression.LessThan(v, iks);
      var l = Expression.Lambda<Func<int, bool>>(less, new ParameterExpression[] { iks }).Compile();

      var predicates = new Predicate<int>[]
      {
        x => l(x)
      };

      var result = CombinePredicates(predicates);

      value = 1000; // This should not affect the call above!
      Assert.IsTrue(result(2));
      Assert.IsTrue(result(5));
      Assert.IsTrue(result(1000));
      Assert.IsFalse(result(-20));
      Assert.IsFalse(result(0));
      Assert.IsFalse(result(-1000));
    }

    public static Predicate<T> CombinePredicates<T>(Predicate<T>[] predicates)
    {
      return item => predicates.All(predicate => predicate(item));
    }

  }

}