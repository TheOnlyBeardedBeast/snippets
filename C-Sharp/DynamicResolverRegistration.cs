// Dynamically register are extendsiontypes of a query/mutation/subscription 
// which extend the IGraphQLAction interface, which is just an empty Interface used for Type location.

var gql = builder.Services.AddGraphQLServer();
gql.AddQueryType<Query>();

var typeExtensions = typeof(Program).Assembly.GetTypes()
    .Where(x => !x.IsAbstract && x.IsClass && x.GetInterface(nameof(IGraphQLAction)) == typeof(IGraphQLAction));

foreach (Type e in typeExtensions)
{
    if (e is not null)
    {
        gql.AddTypeExtension(e);
    }
}
