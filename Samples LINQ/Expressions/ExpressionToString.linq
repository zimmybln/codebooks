<Query Kind="Statements" />

Expression<Func<int, bool>> expression = (v) => (v > 10);

string expressionBody = ((LambdaExpression)expression).Body.ToString();

expressionBody.Dump();