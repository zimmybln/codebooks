<Query Kind="Statements">
  <Reference Relative="System.Linq.Dynamic.dll">C:\Users\Torsten\Dropbox\Codebooks\Samples LINQ\Expressions\System.Linq.Dynamic.dll</Reference>
  <Namespace>System.Linq.Dynamic</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// zusätzlich verwendetes Assembly: 
// 	download https://dynamiclinq.codeplex.com/
//	nuget: http://www.nuget.org/packages/System.Linq.Dynamic/
//  Quelle: http://blog.codebrain.co.uk/post/2009/05/05/C-String-to-LINQ-Expression.aspx

string expressionBody = @"i > 5 and i < 10 and i != 8";
var parameter = Expression.Parameter(typeof(int), "i");

var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, typeof(bool), expressionBody);

var compiled = expression.Compile();

compiled.DynamicInvoke(8).Dump();
compiled.DynamicInvoke(2).Dump();
compiled.DynamicInvoke(7).Dump();
compiled.DynamicInvoke(10).Dump();

